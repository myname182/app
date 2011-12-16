using System;

namespace app.infrastructure.containers.simple
{
  public class DependencyFactoriesProvider:ICreateDependencyFactories
  {
    IPickTheCtorForAType ctor_picker;
    IFetchDependencies container;

    public DependencyFactoriesProvider(IPickTheCtorForAType ctor_picker, IFetchDependencies container)
    {
      this.ctor_picker = ctor_picker;
      this.container = container;
    }

    public ICreateADependency create_factory_to_automatically_create(Type type)
    {
      return new AutomaticDependencyFactory(type, ctor_picker, container);
    }

    public ICreateADependency create_factory_for_instance(object instance)
    {
      return new BasicDependencyFactory(() => instance);
    }
  }
}