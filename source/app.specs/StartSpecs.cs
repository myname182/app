using Machine.Specifications;
using app.tasks.startup;
using app.tasks.startup.steps;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_the_first_startup_step : concern
    {
      Establish c = () =>
      {
        chain_builder = fake.an<ICreateStartupChains>();
        StartupChainBuilderFactory factory = type =>
        {
          type.ShouldEqual(typeof(FirstStep));
          return chain_builder;
        };

        spec.change(() => Start.factory_resolver).to(factory);
      };

      Because b = () =>
        result = Start.by<FirstStep>();

      It should_return_the_startup_chain_builder_created_using_the_first_startup_step = () =>
        result.ShouldEqual(chain_builder);

      static ICreateStartupChains result;
      static ICreateStartupChains chain_builder;
    }

    public class FirstStep : IRunAStartupStep
    {
      public void run()
      {
      }
    }
  }
}