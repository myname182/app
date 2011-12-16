using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using app.tasks.startup.steps;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

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

    public abstract class concern_for_a_created_chain_builder : concern
    {

      Establish c = () =>
      {
        first_step = typeof(AStep);
        all_steps = new List<Type>();
        depends.on(all_steps);
        depends.on(first_step);
      };

      protected static Type first_step;
      protected static IList<Type> all_steps;
    }

    public class when_followed_by_another_step : concern_for_a_created_chain_builder
    {
      Because b = () =>
        result = sut.followed_by<SecondStep>();

      It should_return_a_new_builder_to_carry_on_the_chain = () =>
      {
        var item = result.ShouldBeAn<StartupChainBuilder>();
        item.ShouldNotEqual(sut);
        item.all_steps.ShouldContain(typeof(SecondStep));
        item.all_steps.ShouldNotEqual(all_steps);
      };

      static ICreateStartupChains result;
    }

    public class AStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }
  public class SecondStep:IRunAStartupStep
  {
    public void run()
    {
      throw new NotImplementedException();
    }
  }
  }

}