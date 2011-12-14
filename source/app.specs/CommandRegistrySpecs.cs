 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(CommandRegistry))]  
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
        
    }

   
    public class when_finding_a_command_for_a_request : concern
    {

      public class and_it_has_the_command:when_finding_a_command_for_a_request
      {
        Establish c = () =>
        {
          all_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessASingleRequest>()).ToList();
          request = fake.an<IProvideDetailsToCommands>();
          the_command_that_can_process = fake.an<IProcessASingleRequest>();

          all_commands.Add(the_command_that_can_process);
          the_command_that_can_process.setup(x => x.can_process(request)).Return(true);

          depends.on<IEnumerable<IProcessASingleRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);


        It should_return_the_command_to_the_caller = () =>
          result.ShouldEqual(the_command_that_can_process);

        static IProcessASingleRequest result;
        static IProcessASingleRequest the_command_that_can_process;
        static IProvideDetailsToCommands request;
        static IList<IProcessASingleRequest> all_commands;
      }
         
      public class and_it_does_not_have_the_command:when_finding_a_command_for_a_request
      {
        Establish c = () =>
        {
          the_special_case = depends.on<IProcessASingleRequest>();
          all_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessASingleRequest>()).ToList();
          request = fake.an<IProvideDetailsToCommands>();

          depends.on<IEnumerable<IProcessASingleRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);


        It should_return_the_special_case = () =>
          result.ShouldEqual(the_special_case);


        static IProcessASingleRequest result;
        static IProvideDetailsToCommands request;
        static IList<IProcessASingleRequest> all_commands;
        static IProcessASingleRequest the_special_case;
      }
    }
  }
}
