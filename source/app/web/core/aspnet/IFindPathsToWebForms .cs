namespace app.web.core.aspnet
{
    using System.Web;

    public interface IFindPathsToWebForms 
  {
    IHttpHandler get_path_to_page_that_can_display<ReportModel>();
  }
}