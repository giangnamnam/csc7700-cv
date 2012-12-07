using System;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.GPU;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace OMS.CVApp {
  class SurfDetector : Detector {
    Image<Gray, Byte> modelImage;
    HomographyMatrix homography = null;

    GpuSURFDetector surfGPU;
    SURFDetector surfCPU;
    VectorOfKeyPoint modelKeyPoints;
    VectorOfKeyPoint observedKeyPoints;
    Matrix<int> indices;

    Matrix<byte> mask;
    int k = 2;
    double uniquenessThreshold = 0.8;

    Matrix<float> modelDescriptors;
    BruteForceMatcher<float> matcher;

    GpuImage<Gray, Byte> gpuModelImage;
    GpuMat<float> gpuModelKeyPoints;
    GpuMat<float> gpuModelDescriptors;
    GpuBruteForceMatcher<float> matcher_gpu;

    public SurfDetector(String model) {
      surfCPU = new SURFDetector(500, false);

      Image<Bgr, Byte> color = new Image<Bgr, byte>(model);
      modelImage = color.Convert<Gray, Byte>();

      //extract features from the object image
      modelKeyPoints = surfCPU.DetectKeyPointsRaw(modelImage, null);
      modelDescriptors = surfCPU.ComputeDescriptorsRaw(modelImage, null, modelKeyPoints);

      matcher = new BruteForceMatcher<float>(DistanceType.L2);
      matcher.Add(modelDescriptors);

      //for computers with awesome GPUs...
      if (GpuInvoke.HasCuda) {
        /*surfGPU = new GpuSURFDetector(500, 4, 4, false, 0.01f, true);
        gpuModelImage = new GpuImage<Gray, byte>(modelImage);
        gpuModelKeyPoints = surfGPU.DetectKeyPointsRaw(gpuModelImage, null);
        gpuModelDescriptors = surfGPU.ComputeDescriptorsRaw(gpuModelImage, null, gpuModelKeyPoints);
        matcher_gpu = new GpuBruteForceMatcher<float>(DistanceType.L2);
        modelKeyPoints = new VectorOfKeyPoint();
        surfGPU.DownloadKeypoints(gpuModelKeyPoints, modelKeyPoints);*/
      }
    }

    public override Rectangle[] find(Image<Bgr, Byte> image) {
      Image<Gray, Byte> gray = image.Convert<Gray, Byte>();

      if (true) {
        // extract features from the observed image
        observedKeyPoints = surfCPU.DetectKeyPointsRaw(gray, null);
        Matrix<float> observedDescriptors = surfCPU.ComputeDescriptorsRaw(gray, null, observedKeyPoints);


        indices = new Matrix<int>(observedDescriptors.Rows, k);
        using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k)) {
          matcher.KnnMatch(observedDescriptors, indices, dist, k, null);
          mask = new Matrix<byte>(dist.Rows, 1);
          mask.SetValue(255);
          Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
        }

        int nonZeroCount = CvInvoke.cvCountNonZero(mask);
        if (nonZeroCount >= 4) {
          nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
          if (nonZeroCount >= 4)
            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
        }
      }
      else // USE CUDA!
            {
        // extract features from the observed image
        /*GpuImage<Gray, Byte> gpuObservedImage = new GpuImage<Gray, byte>(image);
        GpuMat<float> gpuObservedKeyPoints = surfGPU.DetectKeyPointsRaw(gpuObservedImage, null);
        GpuMat<float> gpuObservedDescriptors = surfGPU.ComputeDescriptorsRaw(gpuObservedImage, null, gpuObservedKeyPoints);
        GpuMat<int> gpuMatchIndices = new GpuMat<int>(gpuObservedDescriptors.Size.Height, k, 1, true);
        GpuMat<float> gpuMatchDist = new GpuMat<float>(gpuObservedDescriptors.Size.Height, k, 1, true);
        GpuMat<Byte> gpuMask = new GpuMat<byte>(gpuMatchIndices.Size.Height, 1, 1);
        Stream stream = new Stream();

        matcher_gpu.KnnMatchSingle(gpuObservedDescriptors, gpuModelDescriptors, gpuMatchIndices, gpuMatchDist, k, null, stream);
        indices = new Matrix<int>(gpuMatchIndices.Size);
        mask = new Matrix<byte>(gpuMask.Size);

        //gpu implementation of voteForUniquess
        GpuMat<float> col0 = gpuMatchDist.Col(0);
        GpuMat<float> col1 = gpuMatchDist.Col(1);
        GpuInvoke.Multiply(col1, new MCvScalar(uniquenessThreshold), col1, stream);
        GpuInvoke.Compare(col0, col1, gpuMask, CMP_TYPE.CV_CMP_LE, stream);

        observedKeyPoints = new VectorOfKeyPoint();
        surfGPU.DownloadKeypoints(gpuObservedKeyPoints, observedKeyPoints);

        stream.WaitForCompletion();

        gpuMask.Download(mask);
        gpuMatchIndices.Download(indices);

        if (GpuInvoke.CountNonZero(gpuMask) >= 4) {
          int nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
          if (nonZeroCount >= 4)
            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
        }*/
      }

      if (homography != null) {
        Rectangle[] rect = { modelImage.ROI };
        return rect.ToArray();
      }

      return null;
    }

    public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i) {
      Image<Bgr, Byte> image = i.Clone();
      find(i);

      //image = Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, i.Convert<Gray, Byte>(), observedKeyPoints,
      //  indices, new Bgr(255, 255, 255), new Bgr(255, 255, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);

      if (homography != null) {  //draw a rectangle along the projected model
        Rectangle rect = modelImage.ROI;

        if (rect.Width * rect.Height < 10000)
          return image;

        PointF[] pts = new PointF[] { 
               new PointF(rect.Left, rect.Bottom),
               new PointF(rect.Right, rect.Bottom),
               new PointF(rect.Right, rect.Top),
               new PointF(rect.Left, rect.Top)};
        homography.ProjectPoints(pts);

        image.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.CornflowerBlue), 3);

        //image.Draw(rect, new Bgr(Color.CornflowerBlue), 3);
      }

      //foreach (Rectangle item in items)
      //    image.Draw(item, new Bgr(Color.CornflowerBlue), 3);
      return image;
    }
  }
}
