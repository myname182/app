using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using app.tasks.startup.steps;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupChainBuilder))]
  public class StartupChainBuilderSpecs
  {
    public abstract class concern : Observes<ICreateStartupChains,
                                      StartupChainBuilder>
    {
    }

    public class when_created : concern
    {
      Establish c = () =>
      {
        first_step = typeof(AStep);
        all_steps = new List<Type>();
        depends.on(all_steps);
        depends.on(first_step);
      };

      It should_store_the_startup_step_in_the_list_of_all_steps_to_run = () =>
        all_steps.ShouldContainOnly(first_step);

      static IList<Type> all_steps;
      static Type first_step;
    }

    public class AStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}