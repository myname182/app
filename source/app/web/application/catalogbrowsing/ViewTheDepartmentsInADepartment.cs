using System.Collections.Generic;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheDepartmentsInADepartment:ISupportAStory
  {
      IFindDepartments department_repository;
      IDisplayReports report_engine;
      DepartmentItem parentDepartment;

      public ViewTheDepartmentsInADepartment(IFindDepartments department_repository, IDisplayReports report_engine, DepartmentItem parentDepartment)
    {
      this.department_repository = department_repository;
      this.report_engine = report_engine;
      this.parentDepartment = parentDepartment;
    }

    public void process(IProvideDetailsToCommands request)
    {
      report_engine.display(department_repository.get_the_departments_in(parentDepartment));
    }
  }
}