using System.Reflection;
using Machine.Specifications;
using app.infrastructure.containers;
using app.specs.utility;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(GreediestCtorSelection))]
  public class GreediestCtorSelectionSpecs
  {
    public abstract class concern : Observes<IPickTheCtorForAType,
                                      GreediestCtorSelection>
    {
    }

    public class when_picking_the_ctor_on_a_type : concern
    {
      Establish c = () =>
      {
        the_greediest = ObjectFactory.expressions.to_target<AutomaticDependencyFactorySpecs.ItemWithDependencies>()
          .get_ctor_of(() => new AutomaticDependencyFactorySpecs.ItemWithDependencies(null, null, null, null));
      };

      Because b = () =>
        result = sut.get_applicable_ctor_on(typeof(AutomaticDependencyFactorySpecs.ItemWithDependencies));

      It should_return_the_greediest_ctor = () =>
        result.ShouldEqual(the_greediest);

      static ConstructorInfo result;
      static ConstructorInfo the_greediest;
    }
  }
}