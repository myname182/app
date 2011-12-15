using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory:ICreateWebFormViewsToDisplayReports
  {
    public IHttpHandler create_view_that_can_display<ReportModel>(ReportModel the_report)
    {
      throw new System.NotImplementedException();
    }
  }
}