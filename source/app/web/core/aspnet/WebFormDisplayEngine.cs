namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateWebFormViewsToDisplayReports view_factory;

    public WebFormDisplayEngine(ICreateWebFormViewsToDisplayReports view_factory)
    {
      this.view_factory = view_factory;
    }

    public void display<Report>(Report report)
    {
      view_factory.create_view_that_can_display(report);
    }
  }
}