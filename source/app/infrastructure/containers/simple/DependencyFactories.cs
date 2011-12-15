using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure.containers.simple
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
    IEnumerable<ICreateASingleDependency> factory_registry;
    FactoryMissingExceptionFactory exception_factory;

    public DependencyFactories(IEnumerable<ICreateASingleDependency> factory_registry,
                               FactoryMissingExceptionFactory exception_factory)
    {
      this.factory_registry = factory_registry;
      this.exception_factory = exception_factory;
    }

    public ICreateASingleDependency get_factory_that_can_create(Type dependency)
    {
      try
      {
        return factory_registry.First(x => x.can_create(dependency));
      }
      catch (Exception ex)
      {
        throw exception_factory(dependency);
      }
    }
  }
}