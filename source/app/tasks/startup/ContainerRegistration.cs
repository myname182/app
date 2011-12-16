using System.Collections;
using System.Collections.Generic;
using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
  public class ContainerRegistration :IRegisterItemsInTheContainer
  {
    IList<ICreateASingleDependency> factories;
    ICreateDependencyFactories factories_provider;

    public ContainerRegistration(IList<ICreateASingleDependency> factories, ICreateDependencyFactories factories_provider)
    {
      this.factories = factories;
      this.factories_provider = factories_provider;
    }

    public void add_dependency<Implementation>()
    {
      add_dependency<Implementation,Implementation>();
    }

    public void add_dependency<Contract, Implementation>() where Implementation : Contract
    {
      add_factory_for<Contract>(factories_provider.create_factory_to_automatically_create(typeof(Implementation)));
    }

    public void add_dependency<Dependency>(Dependency instance)
    {
      add_factory_for<Dependency>(factories_provider.create_factory_for_instance(instance));
    }

    public void add_factory_for<Contract>(ICreateADependency factory)
    {
      factories.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(Contract)), factory));

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ICreateASingleDependency> GetEnumerator()
    {
      return factories.GetEnumerator();
    }
  }
}