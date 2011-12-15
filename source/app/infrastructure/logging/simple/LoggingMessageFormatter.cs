using System;

namespace app.infrastructure.logging.simple
{
  public delegate string LoggingMessageFormatter(string message,Type calling_type);
}