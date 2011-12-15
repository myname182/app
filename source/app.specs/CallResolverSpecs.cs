using System;
using Machine.Specifications;
using app.infrastructure;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(CallResolver))]
  public class CallResolverSpecs
  {
    public abstract class concern : Observes<IGetTheTypeThatCalledMe,
                                      CallResolver>
    {
    }

    public class when_resolving_the_calling_type : concern
    {
      Because b = () =>
        result = sut.resolve();

      It should_return_the_type_information_for_the_direct_caller_of_the_method = () =>
        result.ShouldEqual(typeof(when_resolving_the_calling_type));

      static Type result;
    }
  }
}