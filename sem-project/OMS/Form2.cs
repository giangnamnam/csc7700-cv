using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using OMS.CVApp.SignDetector;
using OMS.UI;

namespace OMS.CVApp {
  public partial class Form2 : Form {
    #region Fields
    Detector surf_stop_sign_detector_a = new SurfStopSignDetector();
    Detector surf_stop_sign_detector_b = new SurfDetector("stop-sign-model.png");
    Detector surf_stop_sign_detector_c = new SurfDetector("stop-sign-model-blank.png");

    Detector draw_annotation;

    private DetectionAlg[][] typeToAlg;
    private Dictionary<DetectionAlg, Detector> algToDetector;
    private Detector curDetector;
    private ImgList[] typeToImgList;
    private int imgIndex;
    private string[] curImgFiles;
    #endregion

    #region Constructor
    public Form2() {
      InitializeComponent();
    }
    #endregion

    #region Form Events
    private void Form2_Load(object sender, EventArgs e) {
      typeToAlg = new DetectionAlg[6][];
      typeToAlg[(int)DetectionType.CONSTRUCTION] = new DetectionAlg[] { };
      typeToAlg[(int)DetectionType.CROSSWALK] = new DetectionAlg[] { };
      typeToAlg[(int)DetectionType.GUIDANCE] = new DetectionAlg[] { };

      typeToAlg[(int)DetectionType.PEDESTRIAN] = new DetectionAlg[]{
        DetectionAlg.PED_HOG};

      typeToAlg[(int)DetectionType.STOP] = new DetectionAlg[]{
        DetectionAlg.STOPSIGN_SURF, 
        DetectionAlg.STOPSIGN_INT_IMG,
        DetectionAlg.STOPSIGN_OCT};

      typeToAlg[(int)DetectionType.WARNING] = new DetectionAlg[]{
        DetectionAlg.WARN_OSURF, 
        DetectionAlg.WARN_SURF};

      for (int i = 0; i < 6; i++)
        cmbType.Items.Add(DetectionDesc.Type((DetectionType)i));

      cmbType.SelectedIndex = -1;

      typeToImgList = new ImgList[6];
      for (int i = 0; i < 6; i++)
        typeToImgList[i] = new ImgList((DetectionType)i);
      imgIndex = 0;
      curImgFiles = null;

      algToDetector = new Dictionary<DetectionAlg, Detector>() {
        {DetectionAlg.EDGE_CANNY, null},
        {DetectionAlg.PED_HOG, new HogPedestrianDetector()},
        {DetectionAlg.STOPSIGN_INT_IMG, new IntegralImageStopSignDetector()},
        {DetectionAlg.STOPSIGN_OCT, new OctagonStopSignDetector()},
        {DetectionAlg.STOPSIGN_SURF, new SurfStopSignDetector()},
        {DetectionAlg.WARN_OSURF, new OrientedSurfWarningSignDetector()},
        {DetectionAlg.WARN_SURF, new SurfStopSignDetector()}
      };

      btnFocus.Focus();
    }

    private void Form2_Click(object sender, EventArgs e) {
      btnFocus.Focus();
    }

    private void cmbType_SelectedIndexChanged(object sender, EventArgs e) {
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

      string[] imgFiles = typeToImgList[cmbType.SelectedIndex].PosFiles;
      if (imgFiles != null && imgFiles.Length > 0) {
        imgMain.Image = new Bitmap(imgFiles[0]);
        curImgFiles = imgFiles;
      }
      imgIndex = 0;
    }

    private void cmbAlg_SelectedIndexChanged(object sender, EventArgs e) {
      DetectionAlg[] algs = typeToAlg[cmbType.SelectedIndex];
      if (algs != null && algs.Length > 0)
        curDetector = algToDetector[algs[cmbAlg.SelectedIndex]];
    }

    private void btnImgPrev_Click(object sender, EventArgs e) {
      if (curImgFiles != null && curImgFiles.Length > 0) {
        imgIndex--;
        if (imgIndex < 0)
          imgIndex = curImgFiles.Length - 1;
        updateMainImg();
      }
    }

    private void btnImgNext_Click(object sender, EventArgs e) {
      if (curImgFiles != null && curImgFiles.Length > 0) {
        imgIndex++;
        if (imgIndex >= curImgFiles.Length)
          imgIndex = 0;
        updateMainImg();
      }
    }

    private void btnDetect_Click(object sender, EventArgs e) {
      process();
    }
    #endregion

    #region Helper Methods
    private void updateMainImg() {
      imgMain.Image = new Bitmap(curImgFiles[imgIndex]);
    }

    void process() {
      var image = new Image<Bgr, byte>(new Bitmap(curImgFiles[imgIndex]));
      image = curDetector.annotate(image);
      imgMain.Image = image.Bitmap;
    }

    void camera_ImageGrabbed(object sender, EventArgs e) {
      //process(camera.RetrieveBgrFrame());
    }
    #endregion

  }
}