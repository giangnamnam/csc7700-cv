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
using Emgu.CV.Util;

namespace OMS.CVApp
{
    class SurfDetector : Detector
    {
        Image<Gray, Byte> modelImage;
        HomographyMatrix homography = null;

        SURFDetector surfCPU = new SURFDetector(500, false);
        VectorOfKeyPoint modelKeyPoints;
        VectorOfKeyPoint observedKeyPoints;
        Matrix<int> indices;

        Matrix<byte> mask;
        int k = 2;
        double uniquenessThreshold = 0.8;

        Matrix<float> modelDescriptors;
        BruteForceMatcher<float> matcher;

        public SurfDetector(String model)
        {
            Image<Bgr, Byte> color = new Image<Bgr, byte>(model);
            modelImage = color.Convert<Gray, Byte>();

            //extract features from the object image
            modelKeyPoints = surfCPU.DetectKeyPointsRaw(modelImage, null);
            modelDescriptors = surfCPU.ComputeDescriptorsRaw(modelImage, null, modelKeyPoints);

            matcher = new BruteForceMatcher<float>(DistanceType.L2);
            matcher.Add(modelDescriptors);
        }

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            Image<Gray, Byte> gray = image.Convert<Gray, Byte>();

            // extract features from the observed image
            observedKeyPoints = surfCPU.DetectKeyPointsRaw(gray, null);
            Matrix<float> observedDescriptors = surfCPU.ComputeDescriptorsRaw(gray, null, observedKeyPoints);
            

            indices = new Matrix<int>(observedDescriptors.Rows, k);
            using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
            {
                matcher.KnnMatch(observedDescriptors, indices, dist, k, null);
                mask = new Matrix<byte>(dist.Rows, 1);
                mask.SetValue(255);
                Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
            }

            int nonZeroCount = CvInvoke.cvCountNonZero(mask);
            if (nonZeroCount >= 4)
            {
                nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
                if (nonZeroCount >= 4)
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
            }


            return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            find(i);

            image = Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, i.Convert<Gray, Byte>(), observedKeyPoints,
              indices, new Bgr(255, 255, 255), new Bgr(255, 255, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);

            if (homography != null){  //draw a rectangle along the projected model
                Rectangle rect = modelImage.ROI;
                PointF[] pts = new PointF[] { 
               new PointF(rect.Left, rect.Bottom),
               new PointF(rect.Right, rect.Bottom),
               new PointF(rect.Right, rect.Top),
               new PointF(rect.Left, rect.Top)};
                homography.ProjectPoints(pts);

                image.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.Red), 5);
            }

            //foreach (Rectangle item in items)
            //    image.Draw(item, new Bgr(Color.CornflowerBlue), 3);
            return image;
        }
    }
}
