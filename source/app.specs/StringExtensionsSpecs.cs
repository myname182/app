using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using app.infrastructure;

namespace app.specs
{
  [Subject(typeof(String))]
  public class StringExtensionsSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_formatting_a_string  : concern
    {
      It should_return_string_formatted_with_provided_values = () =>
        StringExtensions.format("{0} Boodhoo - {1}","JP",33).ShouldEqual("JP Boodhoo - 33");
    }
  }
}