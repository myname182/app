using System.Collections.Generic;
using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
  public interface IRegisterItemsInTheContainer : IEnumerable<ICreateASingleDependency>
  {
    void register<Implementation>();
    void register<Contract, Implementation>() where Implementation : Contract;
    void register<Dependency>(Dependency instance);
  }
}