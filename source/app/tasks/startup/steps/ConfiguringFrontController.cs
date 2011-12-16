using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup.steps
{
  public class ConfiguringFrontController : IRunAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public ConfiguringFrontController(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.register<ICreateControllerRequests, StubRequestFactory>();
      registration.register<IProcessRequests, FrontController>();
      registration.register<IFindCommands, CommandRegistry>();
      registration.register<IEnumerable<IProcessASingleRequest>, StubCommands>();
      registration.register<IProcessASingleRequest, StubMissingCommand>();
      registration.register<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
      registration.register<GetTheCurrentHttpContext>(() => HttpContext.Current);
      registration.register<IDisplayReports, WebFormDisplayEngine>();
      registration.register<ICreateWebFormViewsToDisplayReports, WebFormViewFactory>();
      registration.register<IFindPathsToWebForms, StubPagePathRegistry>();
    } 
  }
}