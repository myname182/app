 using System.Data.SqlClient;
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
    public class when_creating_the_dependency : concern
    {
      Establish c = () =>
      {
        actual_item = new SqlConnection();
        real_factory = depends.on<ICreateADependency>();

        real_factory.setup(x => x.create()).Return(actual_item);
      };

      Because b = () =>
        result = sut.create();


      It should_return_the_item_created_by_the_actual_factory = () =>
        result.ShouldEqual(actual_item);


      static object result;
      static object actual_item;
      static ICreateADependency real_factory;
    }
  }
}
