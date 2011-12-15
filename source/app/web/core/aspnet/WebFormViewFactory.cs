using System.Web;
using System.Web.Compilation;
using app.infrastructure;
using app.web.core.aspnet.stubs;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateWebFormViewsToDisplayReports
  {
    IFindPathsToWebForms view_path_registry;
    PageFactory page_factory;

    public WebFormViewFactory(IFindPathsToWebForms view_path_registry, PageFactory page_factory)
    {
      this.view_path_registry = view_path_registry;
      this.page_factory = page_factory;
    }

    public WebFormViewFactory() : this(Stub.with<StubPagePathRegistry>(), BuildManager.CreateInstanceFromVirtualPath)
    {
    }

    public IHttpHandler create_view_that_can_display<ReportModel>(ReportModel the_report)
    {
      var view =
        (IDisplayA<ReportModel>)
          page_factory(view_path_registry.get_path_to_page_that_can_display<ReportModel>(),
                       typeof(IDisplayA<ReportModel>));
      view.model = the_report;
      return view;
    }
  }
}