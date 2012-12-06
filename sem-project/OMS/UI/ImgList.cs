using System;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OMS.UI {
  public class ImgList {
    public string[] PosFiles { get; private set; }
    public string[] NegFiles { get; private set; }
    public Image<Bgr, byte>[] PosImgs { get; private set; }
    public Image<Bgr, byte>[] NegImgs { get; private set; }

    public ImgList(DetectionType type) {
      DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
      //di = di.Parent.Parent;
      string relPath = "\\testing\\" + DetectionDesc.Type(type);
      PosFiles = Directory.GetFiles(di.FullName + relPath + "\\positive", "*.jpg");
      NegFiles = Directory.GetFiles(di.FullName + relPath + "\\negative", "*.jpg");

      if (PosFiles != null && PosFiles.Length > 0) {
        Array.Sort<string>(PosFiles);
        PosImgs = new Image<Bgr, byte>[PosFiles.Length];
        for (int i = 0; i < PosFiles.Length; i++)
          PosImgs[i] = new Image<Bgr, byte>(PosFiles[i]);
      }
      else {
        PosImgs = null;
      }

      if (NegFiles != null && NegFiles.Length > 0) {
        Array.Sort<string>(NegFiles);
        NegImgs = new Image<Bgr, byte>[NegFiles.Length];
        for (int i = 0; i < NegFiles.Length; i++)
          NegImgs[i] = new Image<Bgr, byte>(NegFiles[i]);
      }
      else {
        NegImgs = null;
      }
    }

    public static Image<Bgr, byte> GetImageFromPath(string relPath) {
      DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
      //di = di.Parent.Parent;
      return new Image<Bgr, byte>(di.FullName + "\\" + relPath);
    }
  }
}
