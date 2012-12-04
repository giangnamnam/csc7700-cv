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
            Console.WriteLine("Unimplemented: find() in SurfWarningSignDetector.");
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            List<Point> points = (new ReadAnnotationPoints.AnnotationPoints(f)).Points;

            PointF[] src = new PointF[4];
            PointF[] des = new PointF[4];

            src[0] = new PointF(10, 200f);
            src[1] = new PointF(200, 10f);
            src[2] = new PointF(380, 200f);
            src[3] = new PointF(200, 380f);

            for (int x = 0; x < 4; x++)
                des[x] = points[x];

            HomographyMatrix homo = CameraCalibration.GetPerspectiveTransform(src, des);
            image = image.WarpPerspective(homo, image.Width, image.Height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR,
                Emgu.CV.CvEnum.WARP.CV_WARP_INVERSE_MAP, new Bgr(200, 0, 0));

            /*image.DrawPolyline(points.ToArray(), true, new Bgr(Color.Red), 3);
            List<Point> list = new List<Point>();
            foreach(PointF p in src)
                list.Add(new Point((int)p.X, (int)p.Y));*/
            
            //image.DrawPolyline(list.ToArray(), true, new Bgr(Color.Red), 3);

            image.ROI = new Rectangle(0, 0, 400, 400);

            return image;
        }
    }
}
