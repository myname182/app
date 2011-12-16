using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
  public interface IRegisterItemsInTheContainer
  {
    void add_dependency<Implementation>();
    void add_dependency<Contract, Implementation>();
    void add_dependency<Dependency>(Dependency instance);
    void add_factory_for<Contract>(ICreateADependency factory);
  }
}