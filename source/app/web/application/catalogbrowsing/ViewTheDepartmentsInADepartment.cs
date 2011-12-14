using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheDepartmentsInADepartment : ISupportAStory
  {
    IFindDepartments department_repository;
    IDisplayReports report_engine;

    public ViewTheDepartmentsInADepartment(IFindDepartments department_repository, IDisplayReports report_engine)
    {
      this.department_repository = department_repository;
      this.report_engine = report_engine;
    }

    public ViewTheDepartmentsInADepartment():this(new StubDepartmentRepository(),new StubDisplayEngine())
    {
    }

    public void process(IProvideDetailsToCommands request)
    {
      report_engine.display(department_repository.get_the_departments_in(request.map<DepartmentItem>()));
    }
  }
}