using System;

namespace app.infrastructure.containers.simple
{
  public class SimpleContainer : IFetchDependencies
  {
    IFindFactoriesThatCanCreateDependencies factories;
    ItemCreationExceptionFactory exception_factory;

    public SimpleContainer(IFindFactoriesThatCanCreateDependencies factories,
                           ItemCreationExceptionFactory exception_factory)
    {
      this.factories = factories;
      this.exception_factory = exception_factory;
    }

    public Dependency an<Dependency>()
    {
      var factory = factories.get_factory_that_can_create(typeof(Dependency));
      try
      {
        return (Dependency) factory.create();
      }
      catch (Exception ex)
      {
        throw exception_factory(ex, typeof(Dependency));
      }
    }

    public object an(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}