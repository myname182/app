using System;
using Machine.Specifications;
using app.tasks.startup;
using app.tasks.startup.steps;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StartupStepFactory))]
  public class StartupStepFactorySpecs
  {
    public abstract class concern : Observes<ICreateAStartupStep,
                                      StartupStepFactory>
    {
    }

    public class when_creating_a_startup_step : concern
    {
      public class that_follows_the_convention_for_a_startup_step
      {
        Establish c = () =>
        {
          registration = depends.on<IRegisterItemsInTheContainer>();
        };

        Because b = () =>
          result = sut.create_step_from(typeof(FirstStep));

        It should_return_the_step_with_its_dependencies_met = () =>
          result.ShouldBeAn<FirstStep>().registration.ShouldEqual(registration);

        static IRunAStartupStep result;
        static IRegisterItemsInTheContainer registration;
      }
    }

    public class FirstStep : IRunAStartupStep
    {
      public IRegisterItemsInTheContainer registration;

      public FirstStep(IRegisterItemsInTheContainer registration)
      {
        this.registration = registration;
      }

      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}