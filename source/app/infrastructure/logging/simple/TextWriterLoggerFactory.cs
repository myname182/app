using System;

namespace app.infrastructure.logging.simple
{
  public class TextWriterLoggerFactory : ICreateLoggers
  {
    CreateLoggingWriter writer_factory;
    LoggingMessageFormatter formatter;

    public TextWriterLoggerFactory(CreateLoggingWriter writer_factory, LoggingMessageFormatter formatter)
    {
      this.writer_factory = writer_factory;
      this.formatter = formatter;
    }

    public ILogInformation create_logger_for(Type type_that_requested_logging)
    {
      return new TextWriterLogger(writer_factory(), type_that_requested_logging,formatter);
    }
  }
}