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
    class IntegralImageStopSignDetector : StopSignDetector
    {
        public IntegralImageStopSignDetector()
        {
        }

        public double[] differenceVector(double[] g)
        {
            double[] d;
            int N = g.Length;
            d = new double[N];
            int i;
            d[0] = 0;
            for (i = 1; i < N; i++)
            {
                d[i] = g[i] - g[i - 1];
            }
            return d;
        }

        public double findMaxIndex(double[] v)
        {
            int N = v.Length;
            int i;
            int a = 0;
            for (i = 0; i < N; i++)
            {
                if (v[a] > v[i])
                {
                    a = i;
                }
            }
            return a;
        }

        public double findMean(double[] v)
        {
            double N = v.Length;
            int i;
            double mu = 0;
            for (i = 0; i < N; i++)
            {
                mu = mu + v[i];
            }
            mu = mu / N;
            return mu;
        }

        public double findMinIndex(double[] v)
        {
            int N = v.Length;
            int i;
            int a = 0;
            for (i = 0; i < N; i++)
            {
                if (v[a] < v[i])
                {
                    a = i;
                }
            }
            return a;
        }

        public int findCenter(int[] v)
        {
            /*int i;
            double c = 0;
            double sum = 0;
            for (i = 0; i < v.Length; i++)
            {
                c = i * v[i];
                sum = sum + v[i];
            }
            c = (double) c / sum;
            return (int) c;*/
            int N = v.Length;
            int i;
            int a = 0;
            for (i = 0; i < N; i++)
            {
                if (v[a] > v[i])
                {
                    a = i;
                }
            }
            return a;
        }

        public double standardDeviation(int[] v)
        {
            int i;
            double c = (double)findCenter(v);
            double ssq = 0;
            for (i = 0; i < v.Length; i++)
            {
                ssq = ssq + v[i]*Math.Pow((i - c),2);
            }

            long sum = 0;
            foreach (int s in v)
                sum += s;

            ssq = ssq / sum;

            return Math.Sqrt(ssq);
        }

        public double[] fitGaussian(int c, double sigma, int N)
        {
            double a = 1 / (sigma * Math.Sqrt(2 * 3.141592));
            double[] g;
            g = new double[N];
            int i;
            for (i = 0; i < N; i++)
            {
                g[i] = a * Math.Exp(Math.Pow((i-c),2)/(2*Math.Pow(sigma,2)));
            }
            return g;
        }

        public double avgSumSquaredError(int[] v, double[] g) {
            int N = v.Length;
            int i;
            double ssq = 0;
            for (i = 0; i < N; i++)
            {
                ssq = ssq + Math.Pow((v[i] - g[i]),2);
            }
            return ssq / (double)N;
        }

        public override Rectangle[] find(Image<Bgr, Byte> orig)
        {
            Image<Gray, Byte> red = GetRedPixelMask(orig);

            // Make square matrix.
            int S;
            if (orig.Rows > orig.Cols)
            {
                S = orig.Rows;
            }
            else
            {
                S = orig.Cols;
            }
            //Image<Gray, Byte> img = red.Resize(S, S, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            //orig = img.Convert<Bgr, Byte>();

            Image<Bgr, Byte> img = orig.Resize(S, S, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);


            int[] v = new int[img.Rows];
            int i, j; 

            // Compute sum of differences of RHS and LHS integral images.
            for (i = 0; i < img.Rows; i++)
            {
                v[i] = 0;
                for (j = 0; j < img.Cols; j++)
                {
                    v[i] = v[i] + img.Data[i, j, 2] + img.Data[j, i, 2];
                }
            }

            double s_y = (((double)(orig.Rows)) / ((double)img.Rows));
            double s_x = (((double)(orig.Cols)) / ((double)img.Cols));

            int c     = findCenter(v);
            double sigma = standardDeviation(v);

            double[] g;
            g = new double[img.Cols];
            g = fitGaussian(c, sigma, img.Cols);

            double a, b;
            var d = new double[img.Cols];
            d = differenceVector(g);
            a = c - sigma;
            b = c + sigma;

            if (a < 0) {
                a = 0;
            }
            if (b > S) {
                b = S;
            }
            if (b < 0 || a > S) {
                return null;
            }

	            var x = s_x * a;
	            var y = s_y * a;
	            var w = s_x * Math.Abs(b - a);
	            var h = s_y * Math.Abs(b - a);

                Console.WriteLine("a=" + a + " b=" + b + " c=" + c + " s=" + sigma + " s_x" + s_x + " s_y" + s_y);
                Console.WriteLine("\n");
                Console.WriteLine("x=" + x + " y=" + y + " w=" + w + " h=" + h);
                Console.WriteLine("\n");

	            Rectangle R    = new Rectangle((int)x, (int)y, (int)w, (int)h);
	            Rectangle[] ra = new Rectangle[1];
	            ra[0] = R;
	            return ra;
            //}

            //return null;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            /*Image<Bgr, Byte> img = i.Clone();
            Image<Gray, Byte> image = GetRedPixelMask(img);

            Rectangle[] items = find(i);
            if (items == null)
                return img.Convert<Bgr, Byte>();
            foreach (Rectangle item in items)
                image.Draw(item, new Gray(255), 5);
            return image.Convert<Bgr, Byte>();*/

            Image<Bgr, Byte> img = i.Clone();

            Rectangle[] items = find(i);
            if (items == null)
                return img;
            foreach (Rectangle item in items)
                img.Draw(item, new Bgr(Color.Pink), 5);
            return img.Convert<Bgr, Byte>();
        }

        public object Rectangle { get; set; }

        private static Image<Gray, Byte> GetRedPixelMask(Image<Bgr, byte> img)
        {
            /*using (Image<Hsv, Byte> hsv = image.Convert<Hsv, Byte>())
            {
                Image<Gray, Byte>[] channels = hsv.Split();

                try
                {
                    //channels[0] is the mask for hue less than 20 or larger than 160
                    CvInvoke.cvInRangeS(channels[0], new MCvScalar(20), new MCvScalar(160), channels[0]);
                    channels[0]._Not();

                    //channels[1] is the mask for satuation of at least 10, this is mainly used to filter out white pixels
                    channels[1]._ThresholdBinary(new Gray(10), new Gray(255.0));

                    CvInvoke.cvAnd(channels[0], channels[1], channels[0], IntPtr.Zero);
                }
                finally
                {
                    channels[1].Dispose();
                    channels[2].Dispose();
                }
                return channels[0];
            }*/

            img = img.PyrDown().PyrDown().PyrUp().PyrUp();
            Image<Gray, Byte> img2 = img[2] - (img[0] + img[1]);
            return img2;
        }
    }
}
