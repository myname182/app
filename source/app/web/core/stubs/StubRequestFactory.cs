using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IProvideDetailsToCommands create_request_from(HttpContext the_current_context)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsToCommands
    {
    }
  }
}