using System;
using System.IO;

namespace OMS.UI {
  public class ImgList {
    public string[] PosFiles { get; private set; }
    public string[] NegFiles { get; private set; }

    public ImgList(DetectionType type) {
      DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
      di = di.Parent.Parent;
      string relPath = "testing\\" + DetectionDesc.Type(type);
      PosFiles = Directory.GetFiles(String.Format("{0}\\{1}\\{2}", di.FullName, relPath, "positive"), "*.jpg");
      NegFiles = Directory.GetFiles(String.Format("{0}\\{1}\\{2}", di.FullName, relPath, "negative"), "*.jpg");
    }
  }
}
