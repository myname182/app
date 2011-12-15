using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using developwithpassion.specifications.extensions;

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
        the_dependency_resolver = depends.on<IDependancyResolver>();
        the_dependency_resolver.setup(x => x.Resolve<SomeDependency>()).Return(the_dependency);

      };
        
      Because b = () => result = sut.an<SomeDependency>();

      It should_return_the_instance_of_dependancy = () => result.ShouldEqual(the_dependency);
      
      static SomeDependency result;
      static SomeDependency the_dependency;
      static IDependancyResolver the_dependency_resolver;
    }

    public class SomeDependency
    {
    }

    public interface IDependancyResolver {
        SomeDependency Resolve<SomeDpendancy>();
    }
  }

    
}