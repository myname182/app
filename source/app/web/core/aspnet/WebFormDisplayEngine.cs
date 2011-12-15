namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
      ICreateWebFormViewsToDisplayReports viewsCreator; 
      public WebFormDisplayEngine(ICreateWebFormViewsToDisplayReports viewsCreator)
      {
          this.viewsCreator = viewsCreator;
      }

     public void display<Report>(Report report)
     {
        viewsCreator.create_view_that_can_display(report);
     }
  }
}