using Machine.Specifications;
using app.infrastructure;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Stub))]
  public class StubSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_using_a_stub : concern
    {
      Because b = () =>
        result = Stub.with<StubItem>();

      It should_return_an_instance_of_the_requested_stub_class = () =>
        result.ShouldBeAn<StubItem>();

      static StubItem result;
    }
  }

  public class StubItem
  {
  }
}