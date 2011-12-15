using System;

namespace app.infrastructure.containers.simple
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
    public ICreateASingleDependency get_factory_that_can_create(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}