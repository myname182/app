using Machine.Specifications;
using app.infrastructure;
using app.infrastructure.containers;
using app.infrastructure.logging.simple;
using app.tasks.startup;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Startup))]
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_run : concern
    {
      Because b = () =>
        Startup.run();

      It should_have_prepared_the_application_to_run_correctly = () =>
      {
        Container.fetch.an<IProcessRequests>().ShouldBeAn<FrontController>();
        Container.fetch.an<ICreateLoggers>().ShouldBeAn<TextWriterLoggerFactory>();
      };
        
    }
  }
}
