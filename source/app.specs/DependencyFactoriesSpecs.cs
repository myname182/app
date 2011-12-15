 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.infrastructure.containers.simple;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyFactories))]  
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IFindFactoriesThatCanCreateDependencies,
                                      DependencyFactories>
    {
        
    }

   
    public class when_finding_a_type_that_can_create_a_dependency : concern
    {
      public class and_it_has_the_dependency
      {

        Establish c = () =>
        {
          the_factory = fake.an<ICreateASingleDependency>();
          all_dependencies = Enumerable.Range(1,100).Select(x => fake.an<ICreateASingleDependency>()).ToList();
          the_factory.setup(x => x.can_create(typeof(SomeItem))).Return(true);
          depends.on<IEnumerable<ICreateASingleDependency>>(all_dependencies);
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(SomeItem));

        It should_return_the_factory_to_the_caller = () =>
          result.ShouldEqual(the_factory);

        static ICreateASingleDependency result;
        static ICreateASingleDependency the_factory;
        static IList<ICreateASingleDependency> all_dependencies;
      }
    }
  class SomeItem
  {
  }
  }

}
