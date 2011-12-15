using System.Web;
using System.Web.UI;

namespace app.web.core.aspnet
{
  public interface IDisplayA<ReportModel> : IHttpHandler
  {
    ReportModel model { get; set; }
  }

  public class LogicalViewFor<ReportModel> : Page, IDisplayA<ReportModel>
  {
    public ReportModel model { get; set; }
  }
}