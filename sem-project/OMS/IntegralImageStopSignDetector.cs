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

        public override Rectangle[] find(Image<Bgr, Byte> orig)
        {
          //Image<Bgr, Byte> orig = new Image<Bgr, Byte>("stop-sign-model.png");

            // Make square matrix.
            int S;
            if (orig.Rows > orig.Cols) {
                S = orig.Rows;
            } else {
                S = orig.Cols;
            }
            Image<Bgr, Byte> img  = orig.Resize(S, S, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

            int[,] I = new int[img.Rows,img.Cols];
            int[]  D = new int[img.Cols];
            int i,j,a=0,b=0,c=0,d=0;
            
            // Compute integral image.
            for (i=0; i<img.Rows; i++) {
                for (j=0; j<img.Cols; j++) {
                    I[i,j] = img.Data[i,j,2] + I[i-1,j] + I[i,j-1]- I[i-1,j-1];
                }
            }
            
            // Take differences, find maxima a and b.
            D[0] = 0;
            for (i = 1; i < img.Rows; i++) {
                D[i] = I[i, i] - I[i - 1, i - 1];
                if (D[i] > a) {
                    a = i;
                }
                if (D[i] > b && D[i] < a) {
                    b = i;
                }
            }

            // Find inner maxima c and d.
            for (i = a; i < b; i++)
            {
                if (D[i] > c)
                {
                    c = i;
                }
                if (D[i] > c && D[i] < d)
                {
                    d = i;
                }
            }

            float s_y = orig.Rows/img.Rows;
            float s_x = orig.Cols/img.Cols;

            int x = (int)(c*s_x);
            int y = (int)(c*s_y);
            int w = (int)((d-c)*s_x);
            int h = (int)((d-c)*s_y);

            Rectangle R = new Rectangle(x,y,w,h);
            Rectangle[] ra = new Rectangle[1];
            ra[0] = R;
            return ra;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            foreach (Rectangle item in find(i))
                image.Draw(item, new Bgr(Color.Blue), 1);
            return image;
        }

        public object Rectangle { get; set; }
    }
}
