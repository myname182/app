using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.extensions;
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
        factories = depends.on<IFindFactoriesThatCanCreateDependencies>();
        factory = fake.an<ICreateASingleDependency>();

        factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
        factory.setup(x => x.create()).Return(the_dependency);
      };

      Because b = () => 
        result = sut.an<SomeDependency>();

      It should_return_the_instance_of_dependancy = () => 
        result.ShouldEqual(the_dependency);

      static SomeDependency result;
      static object the_dependency;
      static ICreateASingleDependency factory;
      static IFindFactoriesThatCanCreateDependencies factories;
    }

    public class SomeDependency
    {
    }
  }
}