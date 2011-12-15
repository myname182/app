using app.infrastructure;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewMainDepartmentsInTheStore : ISupportAStory
  {
    IFindInformationInTheStore store_catalog;
    IDisplayReports report_engine;

    public ViewMainDepartmentsInTheStore(IFindInformationInTheStore store_catalog, IDisplayReports report_engine)
    {
      this.store_catalog = store_catalog;
      this.report_engine = report_engine;
    }

    public ViewMainDepartmentsInTheStore() : this(Stub.with<StubStoreCatalog>(),
                                                  Stub.with<StubDisplayEngine>())
    {
    }

    public void process(IProvideDetailsToCommands request)
    {
      report_engine.display(store_catalog.get_the_main_departments());
    }
  }
}