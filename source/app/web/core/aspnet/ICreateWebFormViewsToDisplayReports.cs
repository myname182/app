namespace app.web.core.aspnet
{
  public interface ICreateWebFormViewsToDisplayReports
  {
    void create_view_that_can_display<ReportModel>(ReportModel the_report);
  }
}