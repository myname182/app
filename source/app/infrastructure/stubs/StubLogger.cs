using System;

namespace app.infrastructure.stubs
{
  public class StubLogger : ILogInformation
  {
    public void informational(string message)
    {
      Console.Out.WriteLine(message);
    }
  }
}