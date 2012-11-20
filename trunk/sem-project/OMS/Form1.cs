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

namespace OMS.CVApp
{
    public partial class Form1 : Form
    {
        Capture camera;
        Detector stop_sign_detector = new SurfStopSignDetector();
        Detector pedestrian_detector = new HogPedestrianDetector();

        public Form1()
        {
            InitializeComponent();

            Image<Bgr, byte> img = new Image<Bgr, byte>("stop-sign-model.png");

            double[] d = {0,-Math.PI/9,0};
            RotationVector3D m = new RotationVector3D(d);
            

            img = img.WarpPerspective(m.RotationMatrix, img.Width, img.Height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, Emgu.CV.CvEnum.WARP.CV_WARP_INVERSE_MAP, new Bgr(200, 0, 0));

            imageBox1.Image = img;

            //camera = new Capture("C:\\Users\\Robert\\Desktop\\csc7600\\bmod-paper\\matlab\\crude_algorithm\\fount_out6.avi");
            //camera.ImageGrabbed += new Emgu.CV.Capture.GrabEventHandler(camera_ImageGrabbed);
        }

        void camera_ImageGrabbed(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = camera.RetrieveBgrFrame();
            //imageBox1.Image = pedestrian_detector.annotate(image);
            imageBox1.Image = image;
        }
    }
}
