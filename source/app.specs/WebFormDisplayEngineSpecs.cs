using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayReports,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_a_report_model : concern
    {
      Establish c = () =>
      {
        the_report = new TheReportItem();
        the_current_context = ObjectFactory.web.create_http_context();
        view = fake.an<IHttpHandler>();
        view_factory = depends.on<ICreateWebFormViewsToDisplayReports>();
        depends.on<GetTheCurrentHttpContext>(() => the_current_context);

        view_factory.setup(x => x.create_view_that_can_display(the_report)).Return(view);
      };

      Because b = () =>
        sut.display(the_report);


      It should_tell_the_view_to_process_using_the_current_http_context = () =>
        view.received(x => x.ProcessRequest(the_current_context));


      static TheReportItem the_report;
      static ICreateWebFormViewsToDisplayReports view_factory;
      static IHttpHandler view;
      static HttpContext the_current_context;
    }

    public class TheReportItem
    {
    }
  }
}