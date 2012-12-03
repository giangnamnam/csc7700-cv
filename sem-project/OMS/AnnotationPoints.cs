using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ReadAnnotationPoints {
  class AnnotationPoints {
    public List<Point> Points { get; private set; }

    public AnnotationPoints(string filePath) {
      Points = new List<Point>();
      using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
        using (StreamReader sr = new StreamReader(fs)) {
          while (!sr.EndOfStream) {
            string[] line = sr.ReadLine().Split(',');
            Points.Add(new Point(int.Parse(line[0]), int.Parse(line[1])));
          }
        }
      }
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < Points.Count; i++)
        sb.Append(Points[i].ToString());
      return sb.ToString();
    }
  }
}
