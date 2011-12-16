using System;

namespace app.infrastructure
{
  public static class StringExtensions
  {
    public static string format(this String format, params object[] values)
    {
      return String.Format(format, values);
    }
  }
}