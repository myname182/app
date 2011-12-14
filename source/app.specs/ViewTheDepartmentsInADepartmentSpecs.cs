using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsInADepartment))]
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        information_in_the_store_repository = depends.on<IFindInformationInTheStore>();
        display_engine = depends.on<IDisplayReports>();
        request = fake.an<IProvideDetailsToCommands>();
        the_main_department = new DepartmentItem();
        the_sub_departments = new List<DepartmentItem> {new DepartmentItem()};

        request.setup(x => x.map<DepartmentItem>()).Return(the_main_department);

        information_in_the_store_repository.setup(x => x.get_the_departments_in(the_main_department)).Return(the_sub_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_departments_in_a_department = () =>
        display_engine.received(x => x.display(the_sub_departments));

      static IFindInformationInTheStore information_in_the_store_repository;
      static IProvideDetailsToCommands request;
      static IDisplayReports display_engine;
      static DepartmentItem the_main_department;
      static IEnumerable<DepartmentItem> the_sub_departments;
    }
  }
}