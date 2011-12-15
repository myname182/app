using app.infrastructure;
using app.infrastructure.stubs;

namespace app.web.core
{
  public class TimedStory : ISupportAStory
  {
    ITimeThings timer;
    ISupportAStory original;
    ILogInformation logger;

    public TimedStory(ITimeThings timer, ISupportAStory original, ILogInformation logger)
    {
      this.timer = timer;
      this.original = original;
      this.logger = logger;
    }

    public TimedStory(ISupportAStory original) : this(Stub.with<StubTimer>(), original, Stub.with<StubLogger>())
    {
    }

    public void process(IProvideDetailsToCommands request)
    {
      timer.start();
      original.process(request);
      logger.informational(string.Format("The story {0} ran in:{1}", original.GetType().Name, timer.stop()));
    }
  }
}