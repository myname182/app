 using System.Web;
 using Machine.Specifications;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(WebFormViewFactory))]  
  public class WebFormViewFactorySpecs
  {
    public abstract class concern : Observes<ICreateWebFormViewsToDisplayReports,
                                      WebFormViewFactory>
    {
        
    }

   
    public class when_creating_a_view_for_a_report : concern
    {
      Establish c = () =>
      {
        view_path_registry = depends.on<IFindPathsToWebForms>();
        the_page = fake.an<IDisplayA<AReportModel>>();
        path_from_registry = "blah.aspx";
        depends.on<PageFactory>((path,page_type)=>
        {
          path.ShouldEqual(path_from_registry);
          page_type.ShouldEqual(typeof(IDisplayA<AReportModel>));
          return the_page;
        });
        view_path_registry.setup(x => x.get_path_to_page_that_can_display<AReportModel>()).Return(path_from_registry);
        report = new AReportModel();
      };

      Because b = () =>
        result = sut.create_view_that_can_display(report);


      It should_populate_the_page_with_its_data = () =>
        the_page.model.ShouldEqual(report);

      It should_return_the_page_created_by_the_page_factory = () =>
        result.ShouldEqual(the_page);

      static IFindPathsToWebForms view_path_registry;
      static AReportModel report;
      static IHttpHandler result;
      static IDisplayA<AReportModel> the_page;
      static string path_from_registry;
    }

    public class AReportModel
  {
  }
  }

}
