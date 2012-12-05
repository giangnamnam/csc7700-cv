namespace OMS.UI {
  public class Stats {
    public bool Ready { get; private set; }
    public double TotalTime { get; set; }
    public double AvgTime { get; set; }

    public Stats() {
      Reset();
    }

    public void Reset() {
      Ready = false;
      TotalTime = -1;
      AvgTime = -1;
    }

    public void Done() {
      Ready = true;
    }
  }
}
