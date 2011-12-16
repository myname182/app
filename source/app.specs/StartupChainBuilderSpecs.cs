using System;
using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using app.tasks.startup;
using app.tasks.startup.steps;
using developwithpassion.specifications.extensions;
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
      public class and_the_step_has_not_already_been_added : when_followed_by_another_step
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

      public class and_the_step_has_previously_been_added : when_followed_by_another_step
      {
        Establish c = () =>
        {
          all_steps.Add(typeof(SecondStep));
        };

        Because b = () =>
          result = sut.followed_by<SecondStep>();

        It should_not_add_the_step_again = () =>
          all_steps.ShouldContainOnly(first_step, typeof(SecondStep));

        static ICreateStartupChains result;
      }
    }

    public class when_finishing_the_chain : concern_for_a_created_chain_builder
    {
      Establish c = () =>
      {
        step = fake.an<IRunAStartupStep>();
        step_factory = depends.on<ICreateAStartupStep>();

        step_factory.setup(x => x.create_step_from(typeof(AStep))).Return(step);
        step_factory.setup(x => x.create_step_from(typeof(LastStep))).Return(step);
      };

      Because b = () =>
        sut.finish_by<LastStep>();

      It should_run_all_of_the_steps_including_the_last_step = () =>
        step.received(x => x.run()).Times(2);

      static ICreateStartupChains result;
      static IRunAStartupStep step;
      static ICreateAStartupStep step_factory;
    }

    public class AStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }

    public class SecondStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }

    public class LastStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}