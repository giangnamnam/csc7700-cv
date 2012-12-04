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

        Detector draw_annotation;

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
            files = Directory.GetFiles(di.FullName + "\\testing\\warning\\positive\\", "*.jpg");
            //files = Directory.GetFiles(di.FullName + "\\testing\\pedestrian\\positive\\");



            //camera = new Capture("C:\\Users\\Robert\\Desktop\\csc7600\\bmod-paper\\matlab\\crude_algorithm\\fount_out6.avi");
            //camera.ImageGrabbed += new Emgu.CV.Capture.GrabEventHandler(camera_ImageGrabbed);
        }

        void process(Image<Bgr, Byte> image){
            imageBox1.Image = image;
            //image = pedestrian_detector.annotate(image);
            //image = surf_stop_sign_detector_a.annotate(image);
            //image = surf_stop_sign_detector_b.annotate(image);
            //image = surf_stop_sign_detector_c.annotate(image);
            //image = ii_stop_sign_detector.annotate(image);

            /*image = image.PyrDown().PyrDown().PyrUp().PyrUp();
            
            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            Image<Gray, Byte> img2 = image[2] - (image[0] + image[1]);
            Image<Gray, Byte> cannyEdges = img2.Canny(cannyThreshold, cannyThresholdLinking);

            imageBox1.Image = cannyEdges;*/

            image = draw_annotation.annotate(image);

            //image = octagon_stop_sign_detector.annotate(img2.Convert<Bgr, Byte>());
            imageBox2.Image = image;
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
                draw_annotation = new DrawAnnotation(files[i].Substring(0, files[i].Length-4) + "_annotate.txt");

                //debug.Text += (new ReadAnnotationPoints.AnnotationPoints(files[i] + "_annotate.txt")).ToString();

                process(img);

                i++;
                i = i % files.Length;
            }
        }
    }
}
