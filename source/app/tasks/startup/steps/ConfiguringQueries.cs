using app.web.application.catalogbrowsing.stubs;

namespace app.tasks.startup.steps
{
  public class ConfiguringQueries : IRunAStartupStep
  {
    IRegisterItemsInTheContainer registration;

    public ConfiguringQueries(IRegisterItemsInTheContainer registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.add_dependency<GetDepartmentProducts>();
      registration.add_dependency<GetTheMainDepartments>();
      registration.add_dependency<GetDepartmentsInDepartment>();
    } 
  }
}