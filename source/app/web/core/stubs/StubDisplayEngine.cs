using System.Web;

namespace app.web.core.stubs
{
  public class StubDisplayEngine : IDisplayReports
  {
    public void display<Report>(Report report)
    {
      HttpContext.Current.Items.Add("blah", report);
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx", true);
    }
  }
}