using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Structure;

namespace OMS.CVApp
{
    abstract class Detector
    {
        public abstract Rectangle[] find(Image<Bgr, Byte> image);
        public abstract Image<Bgr, Byte> annotate(Image<Bgr, Byte> image);
    }
}
