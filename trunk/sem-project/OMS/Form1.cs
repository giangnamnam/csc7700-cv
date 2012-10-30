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

namespace OMS
{
    public partial class Form1 : Form
    {
        Capture camera;
        public Form1()
        {
            InitializeComponent();

            camera = new Capture();
            camera.ImageGrabbed += new Emgu.CV.Capture.GrabEventHandler(camera_ImageGrabbed);
        }

        void camera_ImageGrabbed(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = camera.RetrieveBgrFrame();
            imageBox1.Image = image;
        }
    }
}
