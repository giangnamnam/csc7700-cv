using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using OMS.CVApp.SignDetector;
using OMS.UI;

namespace OMS.CVApp {
  public partial class Form2 : Form {
    #region Fields
    //--------------------------------------------------------
    private DetectionAlg[][] typeToAlg;
    private Dictionary<DetectionAlg, Detector> algToDetector;
    private Detector curDetector;
    private ImgList[] typeToImgList;
    private int imgIndex;
    private ImgList curImgList;
    private Stats stats;
    private const int NUM_DET_TYPES = 3;
    //--------------------------------------------------------
    #endregion


    #region Constructor
    //--------------------------------------------------------
    public Form2() {
      InitializeComponent();
    }
    //--------------------------------------------------------
    #endregion


    #region Form Events
    //--------------------------------------------------------
    private void Form2_Load(object sender, EventArgs e) {
      lblLoading.Visible = false;

      typeToAlg = new DetectionAlg[NUM_DET_TYPES][];
      typeToAlg[(int)DetectionType.PEDESTRIAN] = new DetectionAlg[]{
        DetectionAlg.PED_HOG};

      typeToAlg[(int)DetectionType.STOP] = new DetectionAlg[]{
        DetectionAlg.STOPSIGN_SURF, 
        DetectionAlg.STOPSIGN_INT_IMG,
        DetectionAlg.STOPSIGN_OCT,
        DetectionAlg.TEXT_TESSERACT,
      };

      typeToAlg[(int)DetectionType.WARNING] = new DetectionAlg[]{
        DetectionAlg.TEXT_TESSERACT,
        DetectionAlg.WARN_OSURF, 
        DetectionAlg.WARN_SURF,
      };

      for (int i = 0; i < NUM_DET_TYPES; i++)
        cmbType.Items.Add(DetectionDesc.Type((DetectionType)i));

      cmbType.SelectedIndex = -1;

      typeToImgList = new ImgList[NUM_DET_TYPES];
      for (int i = 0; i < NUM_DET_TYPES; i++)
        typeToImgList[i] = new ImgList((DetectionType)i);
      imgIndex = 0;
      curImgList = null;

      algToDetector = new Dictionary<DetectionAlg, Detector>() {
        {DetectionAlg.PED_HOG, new HogPedestrianDetector()},
        {DetectionAlg.STOPSIGN_INT_IMG, new IntegralImageStopSignDetector()},
        {DetectionAlg.STOPSIGN_OCT, new OctagonStopSignDetector()},
        {DetectionAlg.STOPSIGN_SURF, new SurfStopSignDetector()},
        {DetectionAlg.TEXT_TESSERACT, new TesseractTextDetector()},
        {DetectionAlg.WARN_OSURF, new OrientedSurfWarningSignDetector()},
        {DetectionAlg.WARN_SURF, new SurfWarningSignDetector()},
      };

      imgMain.Image = ImgList.GetImageFromPath("UI\\PickAType.jpg");

      stats = new Stats();
      btnFocus.Focus();
    }

    private void Form2_Click(object sender, EventArgs e) {
      btnFocus.Focus();
    }

    private void cmbType_SelectedIndexChanged(object sender, EventArgs e) {
      tmrPlay.Enabled = false;
      lblNotice.Text = "";
      btnImgPlay.Text = "Play";

      cmbAlg.Items.Clear();

      DetectionAlg[] algs = typeToAlg[cmbType.SelectedIndex];
      if (algs.Length > 0) {
        for (int i = 0; i < algs.Length; i++)
          cmbAlg.Items.Add(DetectionDesc.Alg(algs[i]));
        cmbAlg.SelectedIndex = -1;
      }
      else {
        cmbAlg.Items.Add("No Algs Found");
        cmbAlg.SelectedIndex = 0;
      }

      curImgList = typeToImgList[cmbType.SelectedIndex];
      imgIndex = 0;

      imgMain.Image = ImgList.GetImageFromPath("UI\\PickAAlg.jpg");
      lblWarning.Text = "";
    }

    private void cmbAlg_SelectedIndexChanged(object sender, EventArgs e) {
      tmrPlay.Enabled = false;
      lblNotice.Text = "";
      btnImgPlay.Text = "Play";

      DetectionAlg[] algs = typeToAlg[cmbType.SelectedIndex];
      if (algs != null && algs.Length > 0)
        curDetector = algToDetector[algs[cmbAlg.SelectedIndex]];
      imgIndex = 0;
      UpdateMainImg();
      UpdateStats();
    }

    private void btnImgPrev_Click(object sender, EventArgs e) {
      if (curImgList != null && curImgList.PosFiles.Length > 0) {
        imgIndex--;
        if (imgIndex < 0)
          imgIndex = curImgList.PosFiles.Length - 1;
        UpdateMainImg();
      }
    }

    private void btnImgNext_Click(object sender, EventArgs e) {
      if (curImgList != null && curImgList.PosFiles.Length > 0) {
        imgIndex++;
        if (imgIndex >= curImgList.PosFiles.Length)
          imgIndex = 0;
        UpdateMainImg();
      }
    }

    private void btnImgPlay_Click(object sender, EventArgs e) {
      if (btnImgPlay.Text == "Play") {
        tmrPlay.Enabled = true;
        btnImgPlay.Text = "Stop";
        lblNotice.Text = "Playing...";
      }
      else {
        tmrPlay.Enabled = false;
        btnImgPlay.Text = "Play";
        lblNotice.Text = "";
      }
    }

    private void tmrStats_Tick(object sender, EventArgs e) {
      if (stats.Ready) {
        if (stats.TotalTime < 0)
          lblTotalTime.Text = "N/A";
        else
          lblTotalTime.Text = stats.TotalTime.ToString() + " ms";

        if (stats.AvgTime < 0)
          lblAvgTime.Text = "N/A";
        else
          lblAvgTime.Text = stats.AvgTime.ToString() + " ms";

        lblLoading.Visible = false;
        tmrStats.Enabled = false;
      }
    }

    private void tmrPlay_Tick(object sender, EventArgs e) {
      btnImgNext.PerformClick();
    }
    //--------------------------------------------------------
    #endregion


    #region Helper Methods
    //--------------------------------------------------------
    private void UpdateStats() {
      lblLoading.Visible = true;
      ClearStats();
      Refresh();

      stats.Reset();
      tmrStats.Enabled = true;

      Thread statThread = new Thread(CalcStats);
      statThread.Start();
    }

    private void ClearStats() {
      lblTotalTime.Text = "";
      lblAvgTime.Text = "";
      lblWeightedTime.Text = "";
      lblRecall.Text = "";
      lblPrecision.Text = "";
    }

    private void CalcStats() {
      int numTestedImages = 0;
      DateTime start;
      TimeSpan totalTime = TimeSpan.Zero;
      for (int i = 0; i < curImgList.PosFiles.Length; i++) {
        try {
          start = DateTime.Now;
          curDetector.setAnnotationFile(curImgList.PosFiles[i]);
          curDetector.annotate(curImgList.PosImgs[i]);
          totalTime += DateTime.Now.Subtract(start);
          numTestedImages++;
        }
        catch {
          // Problem annotating image. Don't count it towards 
          // average, just go on to next image.
        }
      }

      if (numTestedImages < curImgList.PosFiles.Length)
        stats.TotalTime = -1;
      else
        stats.TotalTime = Math.Round(totalTime.TotalMilliseconds);

      if (numTestedImages == 0)
        stats.AvgTime = -1;
      else
        stats.AvgTime = Math.Round(totalTime.TotalMilliseconds / numTestedImages, 2);

      stats.Done();
    }

    private void UpdateMainImg() {
      imgMain.Image = curImgList.PosImgs[imgIndex];
      lblImgName.Text = Path.GetFileNameWithoutExtension(curImgList.PosFiles[imgIndex]);
      lblWarning.Text = "";
      Process();
    }

    void Process() {
      try {
        curDetector.setAnnotationFile(curImgList.PosFiles[imgIndex]);
        imgMain.Image = curDetector.annotate(curImgList.PosImgs[imgIndex].Copy());
      }
      catch {
        lblWarning.Text = "Error Annotating Image";
      }
    }

    void camera_ImageGrabbed(object sender, EventArgs e) {
      //process(camera.RetrieveBgrFrame());
    }
    //--------------------------------------------------------
    #endregion
  }
}