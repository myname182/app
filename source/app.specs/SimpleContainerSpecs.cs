using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(SimpleContainer))]
  public class SimpleContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      SimpleContainer>
    {
    }

    public class when_fetching_a_dependency : concern
    {
      Establish c = () =>
      {
        the_dependency = new SomeDependency();
      };

      Because b = () =>
        result = sut.an<SomeDependency>();

      It should_ = () =>
        result.ShouldEqual(the_dependency);

      static SomeDependency result;
      static SomeDependency the_dependency;
    }

    public class SomeDependency
    {
    }
  }
}