using System;

namespace app.infrastructure.containers.simple
{
  public class SimpleContainer : IFetchDependencies
  {
    IFindFactoriesThatCanCreateDependencies factories;
    ItemCreationExceptionFactory exceptionFactory;
    public SimpleContainer(IFindFactoriesThatCanCreateDependencies factories, ItemCreationExceptionFactory exceptionFactory)
    {
      this.factories = factories;
        this.exceptionFactory = exceptionFactory;
    }

    public Dependency an<Dependency>()
    {
        try
        {
            return (Dependency)factories.get_factory_that_can_create(typeof(Dependency)).create();

        }
        catch (Exception ex)
        {
            throw exceptionFactory(ex, typeof(Dependency));
        }
    }
  }
}