using app.infrastructure.containers;

namespace app.infrastructure.logging
{
  public class Log
  {
    public static ILogInformation an
    {
      get
      {
        return
          Container.fetch.an<ICreateLoggers>().create_logger_for(Container.fetch.an<IGetTheTypeThatCalledMe>().resolve());
      }
    }
  }
}