using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(RequestCommand))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessASingleRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
        depends.on<RequestCriteria>(x => true);

      };
      Because b = () =>
        result = sut.can_process(request);

      It should_make_the_determination_by_using_its_request_criteria = () =>
        result.ShouldBeTrue();

      static bool result;
      static IProvideDetailsToCommands request;
    }
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
        application_behaviour = depends.on<ISupportAStory>();
      };

      Because b = () =>
        sut.process(request);

      It should_trigger_the_application_functionality_for_the_request = () =>
        application_behaviour.received(x => x.process(request));



      static IProvideDetailsToCommands request;
      static ISupportAStory application_behaviour;
    }
  }
}