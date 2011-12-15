using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure.containers.simple
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
	  private IEnumerable<ICreateASingleDependency> asd;

	  public DependencyFactories(IEnumerable<ICreateASingleDependency> asd)
	  {
		  this.asd = asd;
	  }



	  public ICreateASingleDependency get_factory_that_can_create(Type dependency)
	  {
	  	return asd.FirstOrDefault(x => x.can_create(dependency));
	  }
  }
}