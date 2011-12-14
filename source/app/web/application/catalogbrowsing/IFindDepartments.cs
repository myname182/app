using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
  }
}