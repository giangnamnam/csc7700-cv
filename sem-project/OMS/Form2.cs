using System;
using System.Collections.Generic;
using System.Drawing;
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
    private Dictionary<DetectionAlg, double> algToPrecision;
    private Detector curDetector;
    private ImgList[] typeToImgList;
    private int imgIndex;
    private ImgList curImgList;
    private Stats curStats;
    private Stats prevStats;
    private double calcStatProgress;
    private Thread statThread;
    private bool statThreadKill;
    private const int NUM_DET_TYPES = 3;
    private bool firstStatRun;
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
      };

      typeToAlg[(int)DetectionType.WARNING] = new DetectionAlg[]{
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
        {DetectionAlg.WARN_OSURF, new OrientedSurfWarningSignDetector()},
        {DetectionAlg.WARN_SURF, new SurfWarningSignDetector()},
      };

      algToPrecision = new Dictionary<DetectionAlg, double>() {
        {DetectionAlg.PED_HOG, -1},
        {DetectionAlg.STOPSIGN_INT_IMG, -1},
        {DetectionAlg.STOPSIGN_OCT, -1},
        {DetectionAlg.STOPSIGN_SURF, -1},
        {DetectionAlg.WARN_OSURF, -1},
        {DetectionAlg.WARN_SURF, -1}
      };

      imgMain.Image = ImgList.GetImageFromPath("UI\\PickAType.jpg");

      curStats = new Stats();
      prevStats = curStats;
      calcStatProgress = 0;
      firstStatRun = true;
      statThread = null;
      statThreadKill = false;
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
      //UpdateStats();
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
      if (curStats.Ready) {
        if (curStats.TotalTime < 0)
          lblTotalTime.Text = "N/A";
        else
          lblTotalTime.Text = curStats.TotalTime.ToString() + " ms";

        if (curStats.AvgTime < 0)
          lblAvgTime.Text = "N/A";
        else
          lblAvgTime.Text = curStats.AvgTime.ToString() + " ms";

        if (curStats.Precision < 0)
          lblPrecision.Text = "N/A";
        else
          lblPrecision.Text = curStats.Precision.ToString() + " %";

        if (!firstStatRun) {
          if (prevStats.TotalTime < 0 || curStats.TotalTime < prevStats.TotalTime)
            lblTotalTime.ForeColor = Color.Green;
          else if (curStats.TotalTime > prevStats.TotalTime)
            lblTotalTime.ForeColor = Color.Red;
          else
            lblTotalTime.ForeColor = Color.White;

          if (prevStats.AvgTime < 0 || curStats.AvgTime < prevStats.AvgTime)
            lblAvgTime.ForeColor = Color.Green;
          else if (curStats.AvgTime > prevStats.AvgTime)
            lblAvgTime.ForeColor = Color.Red;
          else
            lblAvgTime.ForeColor = Color.White;

          if (prevStats.Precision < 0 || curStats.Precision < prevStats.Precision)
            lblPrecision.ForeColor = Color.Green;
          else if (curStats.Precision > prevStats.Precision)
            lblPrecision.ForeColor = Color.Red;
          else
            lblPrecision.ForeColor = Color.White;
        }

        firstStatRun = false;
        lblLoading.Text = "LOADING STATS... ";
        lblLoading.Visible = false;
        tmrStats.Enabled = false;
      }
      else {
        lblLoading.Text = "LOADING STATS... " + Math.Round(calcStatProgress * 100) + "%";
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
      prevStats = curStats.Copy();

      if (statThread != null) {
        statThreadKill = true;
        statThread.Join();
        lblLoading.Text = "LOADING STATS... ";
        tmrStats.Enabled = false;
        statThreadKill = false;
      }

      lblLoading.Visible = true;
      ClearStats();
      Refresh();

      curStats.Reset();
      calcStatProgress = 0;
      tmrStats.Enabled = true;

      statThread = new Thread(CalcStats);
      statThread.Start();
    }

    private void ClearStats() {
      lblTotalTime.Text = "";
      lblAvgTime.Text = "";
      lblPrecision.Text = "";
    }

    private void CalcStats() {
      DateTime start;
      TimeSpan totalTime = TimeSpan.Zero;
      for (int i = 0; i < curImgList.PosFiles.Length; i++) {
        start = DateTime.Now;
        try {
          curDetector.setAnnotationFile(curImgList.PosFiles[i].Substring(0, curImgList.PosFiles[i].Length - 4) + "_annotate.txt");
          curDetector.annotate(curImgList.PosImgs[i]);
        }
        catch {
          // Problem annotating image
        }
        totalTime += DateTime.Now.Subtract(start);
        calcStatProgress = ((double)i) / curImgList.PosFiles.Length;

        if (statThreadKill) {
          return;
        }
      }

      curStats.TotalTime = Math.Round(totalTime.TotalMilliseconds);
      curStats.AvgTime = Math.Round(totalTime.TotalMilliseconds / curImgList.PosFiles.Length, 2);
      curStats.Precision = algToPrecision[typeToAlg[cmbType.SelectedIndex][cmbAlg.SelectedIndex]];

      curStats.Done();
    }

    private void UpdateMainImg() {
      imgMain.Image = curImgList.PosImgs[imgIndex];
      lblImgName.Text = Path.GetFileNameWithoutExtension(curImgList.PosFiles[imgIndex]);
      lblWarning.Text = "";
      Process();
    }

    void Process() {
      try {
        curDetector.setAnnotationFile(curImgList.PosFiles[imgIndex].Substring(0, curImgList.PosFiles[imgIndex].Length - 4) + "_annotate.txt");
        imgMain.Image = curDetector.annotate(curImgList.PosImgs[imgIndex].Copy());
      }
      catch {
        lblWarning.Text = "Couldn't Find Anything";
      }
    }

    void camera_ImageGrabbed(object sender, EventArgs e) {
      //process(camera.RetrieveBgrFrame());
    }

    private void btnCalculateStats_Click(object sender, EventArgs e) {
      lblPrevTotalTime.Text = lblTotalTime.Text;
      lblPrevAvgTime.Text = lblAvgTime.Text;
      lblPrevPrecision.Text = lblPrecision.Text;

      UpdateStats();
    }
    //--------------------------------------------------------
    #endregion
  }
}