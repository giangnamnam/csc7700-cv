using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.UI {
  public static class DetectionDesc {
    public static string Type(DetectionType type) {
      string name = "";
      switch (type) {
        case DetectionType.PEDESTRIAN:
          name = "Pedestrian";
          break;
        case DetectionType.STOP:
          name = "Stop";
          break;
        case DetectionType.WARNING:
          name = "Warning";
          break;
      }
      return name;
    }

    public static string Alg(DetectionAlg alg) {
      string name = "";

      switch (alg) {
        case DetectionAlg.PED_HOG:
          name = "Hog Pedestrian";
          break;
        case DetectionAlg.STOPSIGN_INT_IMG:
          name = "Integral Images";
          break;
        case DetectionAlg.STOPSIGN_OCT:
          name = "Octagon";
          break;
        case DetectionAlg.STOPSIGN_SURF:
          name = "Surf";
          break;
        case DetectionAlg.WARN_OSURF:
          name = "OSurf";
          break;
        case DetectionAlg.WARN_SURF:
          name = "Surf";
          break;
      }

      return name;
    }
  }
}
