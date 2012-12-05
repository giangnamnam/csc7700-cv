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
        SurfDetector surf = new SurfDetector("models\\pedestrians");

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            return surf.find(image);
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            return surf.annotate(i);
        }
    }
}
