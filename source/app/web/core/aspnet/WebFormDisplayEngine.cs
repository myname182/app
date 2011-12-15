namespace app.web.core.aspnet
{
    using System.Web;

    public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateWebFormViewsToDisplayReports view_factory;

        private readonly HttpContext context;

        public WebFormDisplayEngine(ICreateWebFormViewsToDisplayReports view_factory, HttpContext context)
    {
        this.view_factory = view_factory;
        this.context = context;
    }

        public void display<Report>(Report report)
    {
        view_factory.create_view_that_can_display(report).ProcessRequest(context);
    }
  }
}