using System.Collections;
using System.Collections.Generic;
using app.infrastructure.containers;
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
            yield return new RequestCommand(request => true, new TimedStory(new ViewAReport<IEnumerable<DepartmentItem>,GetTheMainDepartments>(Container.fetch.an<IDisplayReports>(),
              Container.fetch)));
            yield return new RequestCommand(request => true, new TimedStory(new ViewAReport<IEnumerable<DepartmentItem>,GetDepartmentsInDepartment>(Container.fetch.an<IDisplayReports>(),
              Container.fetch)));
            yield return new RequestCommand(request => true, new TimedStory(new ViewAReport<IEnumerable<ProductItem>,GetDepartmentProducts>(Container.fetch.an<IDisplayReports>(),
              Container.fetch)));
    }
  }
}