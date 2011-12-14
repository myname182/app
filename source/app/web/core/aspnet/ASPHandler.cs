using System.Web;
using app.infrastructure;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
  public class ASPHandler : IHttpHandler
  {
    IProcessRequests front_controller;
    ICreateControllerRequests request_factory;

    public ASPHandler(IProcessRequests front_controller, ICreateControllerRequests requestFactory)
    {
      this.front_controller = front_controller;
      request_factory = requestFactory;
    }

    public ASPHandler():this(new FrontController(),Stub.with<StubRequestFactory>())
    {
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.process(request_factory.create_request_from(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}