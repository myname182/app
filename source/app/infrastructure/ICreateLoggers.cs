using System;

namespace app.infrastructure
{
  public interface ICreateLoggers
  {
    ILogInformation create_logger_for(Type type_that_requested_logging);
  }
}