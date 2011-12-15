using System.Collections;
using System.Collections.Generic;

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
      yield break;
      //      yield return new RequestCommand(request => true, new TimedStory(new ViewAReport<IEnumerable<DepartmentItem>, GetDepartmentsInDepartment>()));
      //      yield return new RequestCommand(request => true, new TimedStory(new ViewAReport<IEnumerable<ProductItem>, GetDepartmentProducts>())) ;
      //      yield return new RequestCommand(request => true, new TimedStory(new ViewAReport<IEnumerable<DepartmentItem>, GetTheMainDepartments>()));
    }
  }
}