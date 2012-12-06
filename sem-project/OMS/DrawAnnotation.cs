using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;

namespace OMS.CVApp.SignDetector
{
    class DrawAnnotation : Detector
    {
        String f;
        public DrawAnnotation(String file)
        {
            f = file;
        }

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            Console.WriteLine("Unimplemented: find() in DrawAnnotation.");
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            List<Point> points = (new ReadAnnotationPoints.AnnotationPoints(f)).Points;
            image.DrawPolyline(points.ToArray(), true, new Bgr(Color.Red), 3);
            return image;
        }
    }
}
