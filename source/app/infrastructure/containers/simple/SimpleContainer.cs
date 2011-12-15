namespace app.infrastructure.containers.simple
{
  public class SimpleContainer : IFetchDependencies
  {
    IFindFactoriesThatCanCreateDependencies factories;

    public SimpleContainer(IFindFactoriesThatCanCreateDependencies factories)
    {
      this.factories = factories;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency)factories.get_factory_that_can_create(typeof(Dependency)).create();
    }
  }
}