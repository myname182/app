using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubStoreCatalog : IFindInformationInTheStore
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_the_departments_in(DepartmentItem parent_department)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Sub Department 0")});
    }

    public IEnumerable<ProductItem> get_all_products_in(DepartmentItem department)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem {name = x.ToString("Product 0")});
    }
  }
}