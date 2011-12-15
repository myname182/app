using Machine.Specifications;
using Rhino.Mocks;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class ViewAReportSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewAReport<TheViewModel, TheQuery>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        request = fake.an<IProvideDetailsToCommands>();
        model = new TheViewModel();
      };

      Because b = () =>
        sut.process(request);

      It should_display_products_in_the_department =
        () => display_engine.received(x => x.display(Arg<TheViewModel>.Is.NotNull));

      static IProvideDetailsToCommands request;
      static IDisplayReports display_engine;
      static TheViewModel model;
      static IQueryToFindA<TheViewModel> query;
    }

    public class TheViewModel
    {
    }

    public class TheQuery : IQueryToFindA<TheViewModel>
    {
      public TheViewModel run_using(IProvideDetailsToCommands request)
      {
        return new TheViewModel();
      }
    }
  }
}