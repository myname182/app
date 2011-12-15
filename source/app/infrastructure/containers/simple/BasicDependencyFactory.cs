using System;

namespace app.infrastructure.containers.simple
{
  public class BasicDependencyFactory : ICreateADependency
  {
  	private Func<object> the_connection;

	  public BasicDependencyFactory(Func<object> the_connection)
	  {
	  	this.the_connection = the_connection;
	  }

  	public object create()
    {
      return the_connection.Invoke();
    }
  }
}