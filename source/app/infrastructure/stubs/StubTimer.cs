using System.Diagnostics;

namespace app.infrastructure.stubs
{
  public class StubTimer : ITimeThings
  {
    Stopwatch timer;

    public void start()
    {
      this.timer = new Stopwatch();
      timer.Start();
    }

    public long stop()
    {
      timer.Stop();
      return timer.ElapsedMilliseconds;
    }
  }
}