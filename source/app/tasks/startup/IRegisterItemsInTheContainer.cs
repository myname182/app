using System.Collections.Generic;
using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
  public interface IRegisterItemsInTheContainer : IEnumerable<ICreateASingleDependency>
  {
    void add_dependency<Implementation>();
    void add_dependency<Contract, Implementation>() where Implementation : Contract;
    void add_dependency<Dependency>(Dependency instance);
    void add_factory_for<Contract>(ICreateADependency factory);
  }
}