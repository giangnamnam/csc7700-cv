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

        public override Rectangle[] find(Image<Bgr, Byte> orig){
            List<Rectangle> octList = new List<Rectangle>(); //a box is a rotated rectangle

            // convert to grayscale and filter out noise
            Image<Gray, Byte> gray = orig.Convert<Gray, Byte>().PyrDown().PyrUp();

            // Canny and edge detection
            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                30, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel

            // find octagons
            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
                for(Contour<Point> contours = cannyEdges.FindContours(
                      Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                      Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                   contours != null;
                   contours = contours.HNext){
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                    if (currentContour.Area > 250){ //only consider contours with area greater than 250
                        if (currentContour.Total == 8){ //The contour has 8 vertices.
                            // determine if all the angles in the contour are within [125, 145] degree (should be 135)
                            bool isOctagon = true;
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                            for (int i = 0; i < edges.Length; i++){
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle < 80 || angle > 100){
                                    isOctagon = false;
                                    break;
                                }
                            }

                            if (isOctagon) octList.Add(currentContour.GetMinAreaRect().MinAreaRect());
                        }
                    }
                }

            return octList.ToArray();
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
