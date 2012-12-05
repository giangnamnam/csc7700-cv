using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Structure;

using OMS.CVApp;
using Emgu.CV.OCR;

namespace OMS.CVApp
{
    class TesseractTextDetector : TextDetector
    {
        Tesseract ocr;
        String result = "";

        public TesseractTextDetector()
        {
            ocr = new Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_DEFAULT);
            ocr.Init(".","eng",Tesseract.OcrEngineMode.OEM_DEFAULT);
            ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ-1234567890");
        }

        public override Rectangle[] find(Image<Bgr, Byte> image)
        {
            ocr.Recognize(image.Convert<Gray, Byte>());
            Tesseract.Charactor[] charactors = ocr.GetCharactors();
            result = ocr.GetText();

            List<Rectangle> rects = new List<Rectangle>();
            foreach (Tesseract.Charactor c in charactors)
                rects.Add(c.Region);
            return rects.ToArray();
        }

        public override String ToString()
        {
            return result;
        }

        public override Image<Bgr, Byte> annotate(Image<Bgr, Byte> i)
        {
            Image<Bgr, Byte> image = i.Clone();
            Rectangle[] items = find(i);
            if (items == null)
                return image;
            foreach (Rectangle item in items)
                image.Draw(item, new Bgr(Color.DarkGreen), 3);
            return image;
        }
    }
}
