using System;
using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(SimpleContainer))]
  public class SimpleContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      SimpleContainer>
    {
    }

    public class when_fetching_a_dependency : concern
    {
      public class and_the_factory_for_the_dependency_throws_an_exception_on_creation
      {
        Establish c = () =>
        {
          an_exception = new Exception();
          the_custom_exception = new Exception();
          factories = depends.on<IFindFactoriesThatCanCreateDependencies>();
          depends.on<ItemCreationExceptionFactory>((inner, type) =>
          {
            type.ShouldEqual(typeof(SomeDependency));
            inner.ShouldEqual(an_exception);
            return the_custom_exception;
          });
          factory = fake.an<ICreateASingleDependency>();
          factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
          factory.setup(x => x.create()).Throw(an_exception);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<SomeDependency>());

        It should_throw_the_exception_created_using_the_creation_exception_factory = () =>
          spec.exception_thrown.ShouldEqual(the_custom_exception);

        static ICreateASingleDependency factory;
        static IFindFactoriesThatCanCreateDependencies factories;
        static Exception an_exception;
        static Exception the_custom_exception;
      }
      public class at_runtime
      {
        Establish c = () =>
        {
          the_dependency = new SomeDependency();
          factories = depends.on<IFindFactoriesThatCanCreateDependencies>();
          factory = fake.an<ICreateASingleDependency>();

          factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
          factory.setup(x => x.create()).Return(the_dependency);
        };

        Because b = () => 
          result = sut.an(typeof(SomeDependency));

        It should_return_the_instance_of_dependancy = () => 
          result.ShouldEqual(the_dependency);

        static object result;
        static object the_dependency;
        static ICreateASingleDependency factory;
        static IFindFactoriesThatCanCreateDependencies factories;

      }
      public class and_it_has_the_factory
      {
        Establish c = () =>
        {
          the_dependency = new SomeDependency();
          factories = depends.on<IFindFactoriesThatCanCreateDependencies>();
          factory = fake.an<ICreateASingleDependency>();

          factories.setup(x => x.get_factory_that_can_create(typeof(SomeDependency))).Return(factory);
          factory.setup(x => x.create()).Return(the_dependency);
        };

        Because b = () => 
          result = sut.an<SomeDependency>();

        It should_return_the_instance_of_dependancy = () => 
          result.ShouldEqual(the_dependency);

        static SomeDependency result;
        static object the_dependency;
        static ICreateASingleDependency factory;
        static IFindFactoriesThatCanCreateDependencies factories;

      }
    }

    public class SomeDependency
    {
    }
  }
}