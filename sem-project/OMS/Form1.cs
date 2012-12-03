using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

using OMS.CVApp.SignDetector;
using System.IO;

namespace OMS.CVApp
{
    public partial class Form1 : Form
    {
        Capture camera;
        Detector surf_stop_sign_detector_a = new SurfStopSignDetector();
        Detector surf_stop_sign_detector_b = new SurfDetector("stop-sign-model.png");
        Detector surf_stop_sign_detector_c = new SurfDetector("stop-sign-model-blank.png");

        Detector octagon_stop_sign_detector = new OctagonStopSignDetector();
        Detector ii_stop_sign_detector = new IntegralImageStopSignDetector();
        Detector pedestrian_detector = new HogPedestrianDetector();
        String[] files;
        int i = 0;

        public Form1()
        {
            InitializeComponent();

            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            di = di.Parent.Parent;
            files = Directory.GetFiles(di.FullName + "\\testing\\stop\\positive\\");
            //files = Directory.GetFiles(di.FullName + "\\testing\\pedestrian\\positive\\");

            //int  i = CvInvoke.cvFindFundamentalMat(

            //double[] d = { 0, 0.001, 0};
            //RotationVector3D m = new RotationVector3D(d);

            //img = img.WarpPerspective(m.RotationMatrix, img.Width, img.Height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, Emgu.CV.CvEnum.WARP.CV_WARP_INVERSE_MAP, new Bgr(200, 0, 0));


            //imageBox1.Image = img;
            //camera = new Capture("C:\\Users\\Robert\\Desktop\\csc7600\\bmod-paper\\matlab\\crude_algorithm\\fount_out6.avi");
            //camera.ImageGrabbed += new Emgu.CV.Capture.GrabEventHandler(camera_ImageGrabbed);
        }

        void process(Image<Bgr, Byte> image){
            //image = pedestrian_detector.annotate(image);
            //image = surf_stop_sign_detector_a.annotate(image);
            //image = surf_stop_sign_detector_b.annotate(image);
            //image = surf_stop_sign_detector_c.annotate(image);
            //image = ii_stop_sign_detector.annotate(image);

            image = image.PyrDown().PyrDown().PyrUp().PyrUp();
            
            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            Image<Gray, Byte> img2 = image[2] - (image[0] + image[1]);
            Image<Gray, Byte> cannyEdges = img2.Canny(cannyThreshold, cannyThresholdLinking);

            imageBox1.Image = cannyEdges;

            //image = octagon_stop_sign_detector.annotate(img2.Convert<Bgr, Byte>());
            //imageBox1.Image = image;
        }

        void camera_ImageGrabbed(object sender, EventArgs e){
            process(camera.RetrieveBgrFrame());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (files != null)
            {
                debug.Text += files[i] + "\r\n";
                Image<Bgr, byte> img = new Image<Bgr, byte>(files[i]);
                process(img);

                i++;
                i = i % files.Length;
            }
        }
    }
}
