using System;

namespace app.infrastructure.containers.simple
{
  public class BasicDependencyFactory : ICreateADependency
  {
  	Func<object> factory;

	  public BasicDependencyFactory(Func<object> factory)
	  {
	  	this.factory = factory;
	  }

  	public object create()
    {
  	  return factory();
    }
  }
}