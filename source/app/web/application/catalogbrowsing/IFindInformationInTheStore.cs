using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IFindInformationInTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
    IEnumerable<DepartmentItem> get_the_departments_in(DepartmentItem parent_department);
    IEnumerable<ProductItem> get_all_products_in(DepartmentItem department);
  }
}