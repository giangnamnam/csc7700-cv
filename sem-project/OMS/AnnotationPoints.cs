using System.Drawing;
using System.IO;
using System.Text;

namespace ReadAnnotationPoints {
  class AnnotationPoints {
    public Point[] Points { get; private set; }

    public AnnotationPoints(string filePath) {
      Points = new Point[8];
      using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
        using (StreamReader sr = new StreamReader(fs)) {
          for (int i =0; i < 8; i++) {
            string[] line = sr.ReadLine().Split(',');
            Points[i] = new Point(int.Parse(line[0]), int.Parse(line[1]));
          }
        }
      }
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < 8; i++)
        sb.Append(Points[i].ToString());
      return sb.ToString();
    }
  }
}
