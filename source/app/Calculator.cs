using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;

namespace app
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      ensure_all_are_positive(first, second);

	  using (connection)
	  using (IDbCommand command = connection.CreateCommand())
	  {
	  	command.Connection = connection;
		  command.CommandType = CommandType.Text;
		  
	  	command.ExecuteNonQuery();

	  }



      return first + second;
    }

    static void ensure_all_are_positive(params int[] numbers)
    {
      if (numbers.Any(x => x < 0)) throw new ArgumentException("no!");
    }
  }
}