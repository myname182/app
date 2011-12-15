using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.core.aspnet;

namespace app.web.ui.views
{
    public partial class ProductBrowser : LogicalViewFor<IEnumerable<ProductItem>>
    {
    }
}
