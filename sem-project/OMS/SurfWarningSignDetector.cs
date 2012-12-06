using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Structure;

using OMS.CVApp;

namespace OMS.CVApp.SignDetector
{
    class SurfWarningSignDetector : WarningSignDetector
    {
        List<Detector> detectors = new List<Detector>();

        public SurfWarningSignDetector()
        {
            detectors.Add(new SurfDetector("models\\pedestrians.jpg"));
            detectors.Add(new SurfDetector("models\\slow.jpg"));
        }

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            /*foreach (Detector d in detectors)
                d.find(image);*/
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            foreach (Detector d in detectors)
                image = d.annotate(image);
            return image;
        }
    }
}
