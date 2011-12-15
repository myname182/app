using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    GetTheCurrentHttpContext current_context_resolver;
    ICreateWebFormViewsToDisplayReports view_factory;

    public WebFormDisplayEngine(GetTheCurrentHttpContext current_context_resolver,
                                ICreateWebFormViewsToDisplayReports view_factory)
    {
      this.current_context_resolver = current_context_resolver;
      this.view_factory = view_factory;
    }

    public WebFormDisplayEngine():this(() => HttpContext.Current,null)
    {
    }

    public void display<Report>(Report report)
    {
      view_factory.create_view_that_can_display(report).ProcessRequest(current_context_resolver());
    }
  }
}