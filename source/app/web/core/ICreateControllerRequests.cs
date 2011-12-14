using System.Web;

namespace app.web.core
{
  public interface ICreateControllerRequests
  {
    object create_request_from(HttpContext the_current_context);
  }
}