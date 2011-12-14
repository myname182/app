using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubDepartmentRepository:IFindDepartments
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem{name = x.ToString("Department 0")});
    }
  }
}