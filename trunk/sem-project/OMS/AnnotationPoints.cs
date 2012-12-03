using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ReadAnnotationPoints {
  class AnnotationPoints {
    public List<Point> Points { get; private set; }

    public AnnotationPoints(string filePath) {
      Points = new List<Point>();

      if (File.Exists(filePath)) {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
          using (StreamReader sr = new StreamReader(fs)) {
            while (!sr.EndOfStream) {
              string[] line = sr.ReadLine().Split(',');
              Points.Add(new Point(int.Parse(line[0]), int.Parse(line[1])));
            }
          }
        }
      }
    }

    public Point Get(int i) {
      if (i < 0 || i >= Points.Count)
        return new Point(-1, -1);
      else
        return Points[i];
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < Points.Count; i++)
        sb.Append(Points[i].ToString());
      return sb.ToString();
    }
  }
}
