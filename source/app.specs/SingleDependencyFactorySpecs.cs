 using Machine.Specifications;
 using app.infrastructure.containers.simple;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(SingleDependencyFactory))]  
  public class SingleDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateASingleDependency,
                                      SingleDependencyFactory>
    {
        
    }

   
    public class when_determining_if_it_can_create_a_dependency : concern
    {
      Establish c = () =>
      {
        type_criteria = depends.on<IMatchAType>();
        type_criteria.setup(x => x.matches(typeof(int))).Return(true);
      };

      Because b = () =>
        result = sut.can_create(typeof(int));


      It should_make_its_decision_by_using_its_type_criteria = () =>
        result.ShouldBeTrue();


      static bool result;
      static IMatchAType type_criteria;
    }
  }
}
