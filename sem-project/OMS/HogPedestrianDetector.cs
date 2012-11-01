using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Structure;

using OMS.CVApp;

namespace OMS.CVApp
{
    class HogPedestrianDetector : PedestrianDetector
    {
        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            HOGDescriptor descriptor = new HOGDescriptor();
            descriptor.SetSVMDetector(HOGDescriptor.GetDefaultPeopleDetector());
            return descriptor.DetectMultiScale(image);
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            foreach (Rectangle pedestrain in find(i))
                image.Draw(pedestrain, new Bgr(Color.CornflowerBlue), 1);
            return image;
        }
    }
}
