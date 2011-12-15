using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactories))]
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IFindFactoriesThatCanCreateDependencies,
                                      DependencyFactories>
    {
    }

    public class when_finding_a_type_that_can_create_a_dependency : concern
    {
      public class and_it_does_not_have_the_dependency
      {
        Establish c = () =>
        {
          the_exception = new Exception();
          all_dependencies = Enumerable.Range(1, 100).Select(x => fake.an<ICreateASingleDependency>()).ToList();
          depends.on<IEnumerable<ICreateASingleDependency>>(all_dependencies);
          depends.on<FactoryMissingExceptionFactory>(type =>
          {
            type.ShouldEqual(typeof(SomeItem));
            return the_exception;
          });
        };

        Because b = () =>
          spec.catch_exception(() => sut.get_factory_that_can_create(typeof(SomeItem)));

        It should_throw_the_exception_created_by_its_provided_exception_factory = () =>
          spec.exception_thrown.ShouldEqual(the_exception);

        static ICreateASingleDependency result;
        static ICreateASingleDependency the_factory;
        static IList<ICreateASingleDependency> all_dependencies;
        static Exception the_exception;
      }

      public class and_it_has_the_dependency
      {
        Establish c = () =>
        {
          the_factory = fake.an<ICreateASingleDependency>();
          all_dependencies = Enumerable.Range(1, 100).Select(x => fake.an<ICreateASingleDependency>()).ToList();
          the_factory.setup(x => x.can_create(typeof(SomeItem))).Return(true);
          all_dependencies.Add(the_factory);
          depends.on<IEnumerable<ICreateASingleDependency>>(all_dependencies);
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(SomeItem));

        It should_return_the_factory_to_the_caller = () =>
          result.ShouldEqual(the_factory);

        static ICreateASingleDependency result;
        static ICreateASingleDependency the_factory;
        static IList<ICreateASingleDependency> all_dependencies;
      }
    }

    class SomeItem
    {
    }
  }
}