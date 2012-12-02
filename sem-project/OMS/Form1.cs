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
        Detector ii_stop_sign_detector = new IntegralImageStopSignDetector();
        Detector surf_stop_sign_detector = new SurfStopSignDetector();
        Detector pedestrian_detector = new HogPedestrianDetector();

        public Form1()
        {
            InitializeComponent();

            String[] files = Directory.GetFiles("../");
            foreach (String file in files)
                Console.WriteLine(file);

            Image<Bgr, byte> img = new Image<Bgr, byte>("stop-sign-model.png");
            process(img);

            //double[] d = { 0, 0.001, 0};
            //RotationVector3D m = new RotationVector3D(d);

            //img = img.WarpPerspective(m.RotationMatrix, img.Width, img.Height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, Emgu.CV.CvEnum.WARP.CV_WARP_INVERSE_MAP, new Bgr(200, 0, 0));


            //imageBox1.Image = img;
            //camera = new Capture("C:\\Users\\Robert\\Desktop\\csc7600\\bmod-paper\\matlab\\crude_algorithm\\fount_out6.avi");
            //camera.ImageGrabbed += new Emgu.CV.Capture.GrabEventHandler(camera_ImageGrabbed);
        }

        void process(Image<Bgr, Byte> image){
            image = pedestrian_detector.annotate(image);
            //image = ii_stop_sign_detector.annotate(image);
            image = surf_stop_sign_detector.annotate(image);
            imageBox1.Image = image;
        }

        void camera_ImageGrabbed(object sender, EventArgs e){
            process(camera.RetrieveBgrFrame());
        }
    }
}
