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
    class OctagonStopSignDetector : StopSignDetector
    {
        public OctagonStopSignDetector()
        {
        }

        public override Rectangle[] find(Image<Bgr, Byte> orig)
        {
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            Rectangle[] items = find(i);
            if (items == null)
                return image;
            foreach (Rectangle item in items)
                image.Draw(item, new Bgr(Color.Blue), 3);
            return image;
        }

        public object Rectangle { get; set; }
    }
}
