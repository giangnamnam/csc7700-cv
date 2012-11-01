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
    class IntegralImageStopSignDetector : StopSignDetector
    {
        public IntegralImageStopSignDetector()
        {
        }

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: find() in IntegralImageStopSignDetector.");
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: annotate() in IntegralImageStopSignDetector.");
            return null;
        }
    }
}
