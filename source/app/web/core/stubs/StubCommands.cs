using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubCommands:IEnumerable<IProcessASingleRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessASingleRequest> GetEnumerator()
    {
      yield return new RequestCommand(x => true, new ViewTheProductsInADepartment());
      yield return new RequestCommand(x => true, new ViewTheDepartmentsInADepartment());
      yield return new RequestCommand(x => true, new ViewMainDepartmentsInTheStore());
    }
  }
}