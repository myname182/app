using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
    IEnumerable<DepartmentItem> get_the_departments_in(DepartmentItem parent_department);
  }
}