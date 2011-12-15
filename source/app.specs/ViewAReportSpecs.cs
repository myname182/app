using System;
using Machine.Specifications;
using Rhino.Mocks;
using app.infrastructure.containers;
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
        container = depends.on<IFetchDependencies>();
        query = fake.an<TheQuery>();
        display_engine = depends.on<IDisplayReports>();
        request = fake.an<IProvideDetailsToCommands>();

        model = new TheViewModel();
        container.setup(x => x.an<TheQuery>()).Return(query);
        query.setup(x => x.run_using(request)).Return(model);
      };

      Because b = () =>
        sut.process(request);

      It should_display_products_in_the_department =
        () => display_engine.received(x => x.display(Arg<TheViewModel>.Is.NotNull));

      static IProvideDetailsToCommands request;
      static IDisplayReports display_engine;
      static TheViewModel model;
      static IFetchDependencies container;
      static TheQuery query;
    }

    public class TheViewModel
    {
    }

    public class TheQuery : IQueryToFindA<TheViewModel>
    {
      public virtual TheViewModel run_using(IProvideDetailsToCommands request)
      {
        throw new NotImplementedException();
      }
    }
  }
}