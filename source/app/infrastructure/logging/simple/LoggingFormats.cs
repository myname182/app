using System;
using System.Threading;

namespace app.infrastructure.logging.simple
{
  public class LoggingFormats
  {
    public static LoggingMessageFormatter simple = (message, type) => string.Format("#{0} - {1}", type.Name, message);

    public static LoggingMessageFormatter verbose =
      (message, type) =>
        string.Format("#{0} - {1} - {2} - {3}", type.Name, DateTime.Now, Thread.CurrentThread.Name, message);
  }
}