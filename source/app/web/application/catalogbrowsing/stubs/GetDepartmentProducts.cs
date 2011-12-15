using System.Collections.Generic;
using System.Linq;
using app.web.core;

namespace app.web.application.catalogbrowsing.stubs
{
  public class GetDepartmentProducts : IQueryToFindA<IEnumerable<ProductItem>>
  {
    public IEnumerable<ProductItem> run_using(IProvideDetailsToCommands request)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem {name = x.ToString("Product 0")});
    }
  }
}