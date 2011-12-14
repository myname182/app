using System;
using System.Web;

namespace app.web.core.aspnet
{
  public class ASPHandler : IHttpHandler
  {
    IProcessRequests front_controller;

    public ASPHandler(IProcessRequests front_controller)
    {
      this.front_controller = front_controller;
    }

    public void ProcessRequest(HttpContext context)
    {

      throw new NotImplementedException();
    }

    public bool IsReusable
    {
      get { throw new System.NotImplementedException(); }
    }
  }
}