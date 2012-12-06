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
    class SurfStopSignDetector : StopSignDetector
    {
        private SURFDetector detector;
        private Features2DTracker<float> tracker;
        private MemStorage octagonStorage;
        private Contour<Point> octagon;

        public SurfStopSignDetector()
        {
            detector = new SURFDetector(500, false);

            
            Image<Bgr, Byte> stopSignModel = new Image<Bgr, Byte>("models\\stop-sign-model.png");
            Image<Gray, Byte> redMask = GetRedPixelMask(stopSignModel);
            tracker = new Features2DTracker<float>(detector.DetectFeatures(redMask, null));  
            
            octagonStorage = new MemStorage();
            octagon = new Contour<Point>(octagonStorage);
            octagon.PushMulti(new Point[] { new Point(1, 0), new Point(2, 0), new Point(3, 1), new Point(3, 2),
                new Point(2, 3), new Point(1, 3), new Point(0, 2), new Point(0, 1)}, Emgu.CV.CvEnum.BACK_OR_FRONT.FRONT);

        }

        private static Image<Gray, Byte> GetRedPixelMask(Image<Bgr, byte> image){
            using (Image<Hsv, Byte> hsv = image.Convert<Hsv, Byte>()){
                Image<Gray, Byte>[] channels = hsv.Split();

                try{
                    //channels[0] is the mask for hue less than 20 or larger than 160
                    CvInvoke.cvInRangeS(channels[0], new MCvScalar(20), new MCvScalar(160), channels[0]);
                    channels[0]._Not();

                    //channels[1] is the mask for satuation of at least 10, this is mainly used to filter out white pixels
                    channels[1]._ThresholdBinary(new Gray(10), new Gray(255.0));

                    CvInvoke.cvAnd(channels[0], channels[1], channels[0], IntPtr.Zero);
                }
                finally{
                    channels[1].Dispose();
                    channels[2].Dispose();
                }
                return channels[0];
            }
        }

        private void FindStopSign(Image<Bgr, byte> img, List<Image<Gray, Byte>> stopSignList, List<Rectangle> boxList, Contour<Point> contours)
        {
            for (; contours != null; contours = contours.HNext)
            {
                contours.ApproxPoly(contours.Perimeter * 0.02, 0, contours.Storage);
                if (contours.Area > 200)
                {
                    double ratio = CvInvoke.cvMatchShapes(octagon, contours, Emgu.CV.CvEnum.CONTOURS_MATCH_TYPE.CV_CONTOURS_MATCH_I3, 0);

                    if (ratio > 0.1) //not a good match of contour shape
                    {
                        Contour<Point> child = contours.VNext;
                        if (child != null)
                            FindStopSign(img, stopSignList, boxList, child);
                        continue;
                    }

                    Rectangle box = contours.BoundingRectangle;

                    Image<Gray, Byte> candidate;
                    using (Image<Bgr, Byte> tmp = img.Copy(box))
                        candidate = tmp.Convert<Gray, byte>();

                    //set the value of pixels not in the contour region to zero
                    using (Image<Gray, Byte> mask = new Image<Gray, byte>(box.Size))
                    {
                        mask.Draw(contours, new Gray(255), new Gray(255), 0, -1, new Point(-box.X, -box.Y));

                        double mean = CvInvoke.cvAvg(candidate, mask).v0;
                        candidate._ThresholdBinary(new Gray(mean), new Gray(255.0));
                        candidate._Not();
                        mask._Not();
                        candidate.SetValue(0, mask);
                    }

                    ImageFeature<float>[] features = detector.DetectFeatures(candidate, null);

                    Features2DTracker<float>.MatchedImageFeature[] matchedFeatures = tracker.MatchFeature(features, 2);

                    int goodMatchCount = 0;
                    foreach (Features2DTracker<float>.MatchedImageFeature ms in matchedFeatures)
                        if (ms.SimilarFeatures[0].Distance < 0.5) goodMatchCount++;

                    if (goodMatchCount >= 10)
                    {
                        boxList.Add(box);
                        stopSignList.Add(candidate);
                    }
                }
            }
        }

        public void DetectStopSign(Image<Bgr, byte> img, List<Image<Gray, Byte>> stopSignList, List<Rectangle> boxList)
        {
            Image<Bgr, Byte> smoothImg = img.SmoothGaussian(5, 5, 1.5, 1.5);
            Image<Gray, Byte> smoothedRedMask = GetRedPixelMask(smoothImg);

            //Use Dilate followed by Erode to eliminate small gaps in some countour.
            smoothedRedMask._Dilate(1);
            smoothedRedMask._Erode(1);

            using (Image<Gray, Byte> canny = smoothedRedMask.Canny(new Gray(100), new Gray(50)))
            using (MemStorage stor = new MemStorage())
            {
                Contour<Point> contours = canny.FindContours(
                   Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                   Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE,
                   stor);
                FindStopSign(img, stopSignList, boxList, contours);
            }
        }


        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            List<Image<Gray, Byte>> stopSignList = new List<Image<Gray, byte>>();
            List<Rectangle> stopSignBoxList = new List<Rectangle>();
            DetectStopSign(image, stopSignList, stopSignBoxList);

            return stopSignBoxList.ToArray();
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            Rectangle[] items = find(i);
            if (items == null)
                return image;
            foreach (Rectangle item in items)
                image.Draw(item, new Bgr(Color.CornflowerBlue), 3);
            return image;
        }
    }
}
