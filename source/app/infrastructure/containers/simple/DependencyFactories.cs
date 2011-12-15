using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure.containers.simple
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
	  private IEnumerable<ICreateASingleDependency> factory_registry;
      private FactoryMissingExceptionFactory exceptionfactory;

	  public DependencyFactories(IEnumerable<ICreateASingleDependency> factory_registry, FactoryMissingExceptionFactory exceptionfactory)
	  {
		  this.factory_registry = factory_registry;
	  }

	  public ICreateASingleDependency get_factory_that_can_create(Type dependency)
	  {
          try
          {
              return factory_registry.First(x => x.can_create(dependency));
          }
	  	catch(Exception ex)
	  	{
	  	    
	  	}
	  }
  }
}