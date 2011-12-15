using System;
using System.IO;

namespace app.infrastructure.logging.simple
{
  public class TextWriterLogger : ILogInformation
  {
    public TextWriter writer;
    public Type calling_type;
    public LoggingMessageFormatter formatter;

    public TextWriterLogger(TextWriter writer, Type calling_type, LoggingMessageFormatter formatter)
    {
      this.writer = writer;
      this.calling_type = calling_type;
      this.formatter = formatter;
    }

    public void informational(string message)
    {
      writer.WriteLine(formatter(message,calling_type));
    }
  }
}