using app.infrastructure;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheProductsInADepartment:ISupportAStory
  {
    IFindInformationInTheStore store_catalog;
    IDisplayReports display_engine;

    public ViewTheProductsInADepartment(IFindInformationInTheStore store_catalog, IDisplayReports display_engine)
    {
      this.store_catalog = store_catalog;
      this.display_engine = display_engine;
    }

    public ViewTheProductsInADepartment():this(Stub.with<StubStoreCatalog>(),Stub.with<StubDisplayEngine>())
    {
    }

    public void process(IProvideDetailsToCommands request)
    {
      display_engine.display(store_catalog.get_all_products_in(request.map<DepartmentItem>()));
    }
  }
}