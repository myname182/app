using System;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(BasicDependencyFactory))]
  public class BasicDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateADependency, BasicDependencyFactory>
    {
    }

    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        the_connection = new object();
        depends.on<Func<object>>(() => the_connection);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_created_by_the_factory_delegate = () =>
        result.ShouldEqual(the_connection);

      static object result;
      static object the_connection;
    }
  }
}