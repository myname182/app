using System;
using System.Web;

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

    public void ProcessRequest(HttpContext context)
    {
        front_controller.process(request_factory.create_request_from(context));
    }

    public bool IsReusable
    {
      get { throw new System.NotImplementedException(); }
    }
  }
}