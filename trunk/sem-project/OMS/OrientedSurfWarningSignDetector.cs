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
    class OrientedSurfWarningSignDetector : WarningSignDetector
    {
        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: find() in OrientedSurfWarningSignDetector.");
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: annotate() in OrientedSurfWarningSignDetector.");
            return null;
        }
    }
}
