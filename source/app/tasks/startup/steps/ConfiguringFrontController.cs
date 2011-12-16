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
      registration.add_dependency<ICreateControllerRequests, StubRequestFactory>();
      registration.add_dependency<IProcessRequests, FrontController>();
      registration.add_dependency<IFindCommands, CommandRegistry>();
      registration.add_dependency<IEnumerable<IProcessASingleRequest>, StubCommands>();
      registration.add_dependency<IProcessASingleRequest, StubMissingCommand>();
      registration.add_dependency<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
      registration.add_dependency<GetTheCurrentHttpContext>(() => HttpContext.Current);
      registration.add_dependency<IDisplayReports, WebFormDisplayEngine>();
      registration.add_dependency<ICreateWebFormViewsToDisplayReports, WebFormViewFactory>();
      registration.add_dependency<IFindPathsToWebForms, StubPagePathRegistry>();
    } 
  }
}