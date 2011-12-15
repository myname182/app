using System;

namespace app.infrastructure.containers.simple
{
  public interface IFindFactoriesThatCanCreateDependencies
  {
    ICreateASingleDependency get_factory_that_can_create(Type dependency);
  }
}