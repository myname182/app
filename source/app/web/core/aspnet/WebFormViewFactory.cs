using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory:ICreateWebFormViewsToDisplayReports
  {
      private readonly IFindPathsToWebForms viewPathRegistry;

      public WebFormViewFactory(IFindPathsToWebForms view_path_registry)
      {
          this.viewPathRegistry = view_path_registry;
      }

      public IHttpHandler create_view_that_can_display<ReportModel>(ReportModel the_report)
      {
         return viewPathRegistry.get_path_to_page_that_can_display<ReportModel>();
      }
  }
}