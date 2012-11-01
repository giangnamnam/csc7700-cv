using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;

using OMS.CVApp;

namespace OMS.CVApp.SignDetector
{
    class SurfStopSignDetector : StopSignDetector
    {
        private SURFDetector detector;
        private Features2DTracker<float> tracker;
        private MemStorage octagonStorage;
        private Contour<Point> octagon;

        public SurfStopSignDetector()
        {
            detector = new SURFDetector(500, false);

            
            Image<Bgr, Byte> stopSignModel = new Image<Bgr, Byte>("stop-sign-model.png");
            //Image<Gray, Byte> redMask = GetRedPixelMask(stopSignModel);
            //tracker = new Features2DTracker<float>(detector.DetectFeatures(redMask, null));  
            
            octagonStorage = new MemStorage();
            octagon = new Contour<Point>(octagonStorage);
            octagon.PushMulti(new Point[] { new Point(1, 0), new Point(2, 0), new Point(3, 1), new Point(3, 2),
                new Point(2, 3), new Point(1, 3), new Point(0, 2), new Point(0, 1)}, Emgu.CV.CvEnum.BACK_OR_FRONT.FRONT);

        }

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: find() in SurfStopSignDetector.");
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: annotate() in SurfStopSignDetector.");
            return null;
        }
    }
}
