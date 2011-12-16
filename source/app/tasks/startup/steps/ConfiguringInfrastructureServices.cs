using System;
using app.infrastructure;
using app.infrastructure.logging.simple;

namespace app.tasks.startup.steps
{
  public class ConfiguringInfrastructureServices : IRunAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public ConfiguringInfrastructureServices(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.add_dependency<CreateLoggingWriter>(() => Console.Out);
      registration.add_dependency(LoggingFormats.simple);
      registration.add_dependency<ICreateLoggers, TextWriterLoggerFactory>();
    }
  }
}