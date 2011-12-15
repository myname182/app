using Machine.Specifications;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(TypeMatchesSpecificType))]
  public class TypeMatchesSpecificTypeSpecs
  {
    public abstract class concern : Observes<IMatchAType,
                                      TypeMatchesSpecificType>
    {
    }

    public class when_matching_a_type : concern
    {
      Establish c = () =>
      {
        depends.on(typeof(OurItem));
      };

      It should_match_if_the_type_it_was_created_with_is_the_same = () =>
      {
        sut.matches(typeof(int)).ShouldBeFalse();
        sut.matches(typeof(OurItem)).ShouldBeTrue();
      };
    }

    public class OurItem
    {
    }
  }
}