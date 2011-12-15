using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

namespace app.web.core.stubs
{
  public class StubCommands : IEnumerable<IProcessASingleRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessASingleRequest> GetEnumerator()
    {
      yield return new RequestCommand(x => true, new TimedStory(new ViewAReport<IEnumerable<ProductItem>, GetDepartmentProducts>())) ;
      yield return new RequestCommand(x => true, new TimedStory(new ViewAReport<IEnumerable<DepartmentItem>, GetTheMainDepartments>()));
      yield return new RequestCommand(x => true, new TimedStory(new ViewAReport<IEnumerable<DepartmentItem>, GetDepartmentsInDepartment>()));
    }
  }
}