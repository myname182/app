using Machine.Specifications;
using app.infrastructure;
using app.infrastructure.containers;
using app.infrastructure.logging;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Log))]
  public class LogSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_providing_access_to_a_logger : concern
    {
      Establish c = () =>
      {
        type_bound_logger = fake.an<ILogInformation>();
        log_factory = fake.an<ICreateLoggers>();
        call_resolver = fake.an<IGetTheTypeThatCalledMe>();

        container = fake.an<IFetchDependencies>();
        ContainerFacadeResolver resolver = () => container;

        spec.change(() => Container.facade_resolver).to(resolver);
        log_factory.setup(x => x.create_logger_for(typeof(when_providing_access_to_a_logger))).Return(type_bound_logger);
        container.setup(x => x.an<ICreateLoggers>()).Return(log_factory);
        container.setup(x => x.an<IGetTheTypeThatCalledMe>()).Return(call_resolver);
        call_resolver.setup(x => x.resolve()).Return(typeof(when_providing_access_to_a_logger));
      };

      Because b = () =>
        result = Log.an;

      It should_return_a_logger_bound_to_the_type_that_requested_logging = () =>
        result.ShouldEqual(type_bound_logger);

      static ILogInformation result;
      static ILogInformation type_bound_logger;
      static ICreateLoggers log_factory;
      static IFetchDependencies container;
      static IGetTheTypeThatCalledMe call_resolver;
    }
  }
}