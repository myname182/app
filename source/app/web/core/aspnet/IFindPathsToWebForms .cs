namespace app.web.core.aspnet
{
  public interface IFindPathsToWebForms
  {
    string get_path_to_page_that_can_display<ReportModel>();
  }
}