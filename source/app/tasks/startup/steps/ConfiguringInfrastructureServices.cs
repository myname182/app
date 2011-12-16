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
      registration.register<CreateLoggingWriter>(() => Console.Out);
      registration.register(LoggingFormats.simple);
      registration.register<ICreateLoggers, TextWriterLoggerFactory>();
    }
  }
}