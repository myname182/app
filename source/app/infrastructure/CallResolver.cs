using System;
using System.Diagnostics;

namespace app.infrastructure
{
  public class CallResolver : IGetTheTypeThatCalledMe
  {
    public Type resolve()
    {
      return new StackFrame(1).GetMethod().DeclaringType;
    }
  }
}