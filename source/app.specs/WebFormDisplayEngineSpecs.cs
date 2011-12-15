using Machine.Specifications;
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
        view_factory = depends.on<ICreateWebFormViewsToDisplayReports>();
      };
      Because b = () =>
        sut.display(the_report);

      It should_get_the_view_that_can_display_the_report = () =>
        view_factory.received(x => x.create_view_that_can_display(the_report));


      static TheReportItem the_report;
      static ICreateWebFormViewsToDisplayReports view_factory;
    }

    public class TheReportItem
    {
    }
  }
}