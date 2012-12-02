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

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            Rectangle[] items = find(i);
            if (items == null)
                return image;
            foreach (Rectangle item in items)
                image.Draw(item, new Bgr(Color.DarkGreen), 3);
            return image;
        }
    }
}
