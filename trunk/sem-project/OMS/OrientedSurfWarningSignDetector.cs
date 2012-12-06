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
        Image<Bgr, Byte> image;
        String annotation_file = "";
        Detector surf = new SurfWarningSignDetector();

        public override void setAnnotationFile(String f)
        {
            annotation_file = f;
        }

        // orients the image so that the plane of the sign is parallel to the camera
        Image<Bgr, Byte> orient(Image<Bgr, Byte> i)
        {
            if (annotation_file == "")
                return null;

            image = i.Clone();
            List<Point> points = (new ReadAnnotationPoints.AnnotationPoints(annotation_file)).Points;

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

            image.ROI = new Rectangle(0, 0, 400, 400);

            return image;
        }

        public override Rectangle[] find(Image<Bgr, Byte> i)
        {
            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            return surf.annotate(orient(i));
        }
    }
}
