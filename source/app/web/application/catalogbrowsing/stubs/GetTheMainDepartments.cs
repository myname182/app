using System.Collections.Generic;
using System.Linq;
using app.web.core;

namespace app.web.application.catalogbrowsing.stubs
{
  public class GetTheMainDepartments : IQueryToFindA<IEnumerable<DepartmentItem>>
  {
    public IEnumerable<DepartmentItem> run_using(IProvideDetailsToCommands request)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }
  }
}