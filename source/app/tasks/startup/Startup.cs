using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by<ConfiguringInfrastructureServices>()
        .followed_by<ConfiguringFrontController>()
        .followed_by<ConfiguringFrontController>()
        .finish_by<ConfiguringQueries>();
    }
  }
}