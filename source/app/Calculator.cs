using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace app
{
  public class Calculator : ICalculate
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection, int number, int number2)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      ensure_all_are_positive(first, second);

      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return first + second;
    }

    static void ensure_all_are_positive(params int[] numbers)
    {
      if (numbers.Any(x => x < 0)) throw new ArgumentException("no!");
    }

    public void shut_off()
    {
      if (Thread.CurrentPrincipal.IsInRole("this does not matter")) return;

      throw new SecurityException();
    }
  }
}