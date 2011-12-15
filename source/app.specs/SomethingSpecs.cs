using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class SomethingSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      Something>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
      };

      Because b = () =>
        sut.process(request);


      It should_ = () =>
      {

      };

      static IProvideDetailsToCommands request;
    }
  }
}