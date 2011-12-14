using System;
using System.Data;
using System.Linq;

namespace app
{
  public class Calculator
  {
    public Calculator(IDbConnection connection)
    {
        connection.Open();
    }

    public int add(int first, int second)
    {
      ensure_all_are_positive(first, second);

      return first + second;
    }

    static void ensure_all_are_positive(params int[] numbers)
    {
      if(numbers.Any(x => x<0)) throw new ArgumentException("no!");
    }
  }
}