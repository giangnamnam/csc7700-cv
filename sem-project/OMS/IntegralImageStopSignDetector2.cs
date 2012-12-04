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
            ssq = ssq / v.Sum();
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
            //Image<Bgr, Byte> orig = new Image<Bgr, Byte>("stop-sign-model.png");

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

            float s_y = orig.Rows / img.Rows;
            float s_x = orig.Cols / img.Cols;

            int c     = findCenter(v);
            double sigma = standardDeviation(v);

            double[] g;
            g = new double[img.Cols];
            g = fitGaussian(c, sigma, img.Cols);

            double a, b;
            var d = new double[img.Cols];
            d = differenceVector(g);
            a = findMinIndex(d);
            b = findMaxIndex(d);

            //if (a < b) {
	            var x = s_x * a;
	            var y = s_y * a;
	            var w = s_x * Math.Abs(b - a);
	            var h = s_y * Math.Abs(b - a);

                Console.WriteLine("a=" + a + " b=" + b + " c=" + c + " s=" + sigma);
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
            Image<Bgr, Byte> image = i.Clone();
            Rectangle[] items = find(i);
            if (items == null)
                return image;
            foreach (Rectangle item in items)
                image.Draw(item, new Bgr(Color.Pink), 5);
            return image;
        }

        public object Rectangle { get; set; }
    }
}
