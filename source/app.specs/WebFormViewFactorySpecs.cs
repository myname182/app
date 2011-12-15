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
        the_page = fake.an<IHttpHandler>();
        depends.on<PageFactory>(() => the_page);
        report = new AReportModel();
      };

      Because b = () =>
        result = sut.create_view_that_can_display(report);


      It should_get_the_path_to_the_view_that_can_display_the_report = () =>
        view_path_registry.received(x => x.get_path_to_page_that_can_display<AReportModel>());

      It should_return_the_page_created_by_the_page_factory = () =>
        result.ShouldEqual(the_page);
        

      static IFindPathsToWebForms view_path_registry;
      static AReportModel report;
      static IHttpHandler result;
      static IHttpHandler the_page;
    }

    public class AReportModel
  {
  }
  }

}
