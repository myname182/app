using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      //startup steps can only be added once (ignore repeated adds of the same step)
      //none of the commands should run until the finish_by method is called
      //tests are mandatory (first or after)

      //once finish by is called, there is no further chaining

//      Start.by<ConfiguringInfrastructureServices>()
//        .followed_by<ConfiguringFrontController>()
//        .finish_by<ConfiguringQueries>();
    }
  }
}