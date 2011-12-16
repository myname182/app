using System.Data;
using System.Reflection;
using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using app.specs.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(AutomaticDependencyFactory))]
  public class AutomaticDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateADependency,
                                      AutomaticDependencyFactory>
    {
    }

    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        ctor_selection_strategy = depends.on<IPickTheCtorForAType>();
        depends.on(typeof(ItemWithDependencies));
        container = depends.on<IFetchDependencies>();
        greediest_ctor =
          ObjectFactory.expressions.to_target<ItemWithDependencies>().get_ctor_of(
            () => new ItemWithDependencies(null, null, null, null));

        the_connection = fake.an<IDbConnection>();
        the_command = fake.an<IDbCommand>();
        the_reader = fake.an<IDataReader>();
        the_other = fake.an<OtherItem>();

        ctor_selection_strategy.setup(x => x.get_applicable_ctor_on(typeof(ItemWithDependencies))).Return(greediest_ctor);
        container.setup(x => x.an(typeof(IDbConnection))).Return(the_connection);
        container.setup(x => x.an(typeof(IDbCommand))).Return(the_command);
        container.setup(x => x.an(typeof(IDataReader))).Return(the_reader);
        container.setup(x => x.an(typeof(OtherItem))).Return(the_other);
 
      };
      Because b = () =>
        result = sut.create();

      It should_return_the_type_with_all_its_dependencies_filled = () =>
      {
        var item = result.ShouldBeAn<ItemWithDependencies>();
        item.connection.ShouldEqual(the_connection);
        item.command.ShouldEqual(the_command);
        item.reader.ShouldEqual(the_reader);
        item.other.ShouldEqual(the_other);
      };

      static object result;
      static IDbConnection the_connection;
      static IDbCommand the_command;
      static IDataReader the_reader;
      static OtherItem the_other;
      static IFetchDependencies container;
      static IPickTheCtorForAType ctor_selection_strategy;
      static ConstructorInfo greediest_ctor;
    }

    public class ItemWithDependencies
    {
      public IDbConnection connection;
      public IDbCommand command;
      public IDataReader reader;
      public OtherItem other;

      public ItemWithDependencies(IDbConnection connection, IDbCommand command, IDataReader reader, OtherItem other)
      {
        this.connection = connection;
        this.command = command;
        this.reader = reader;
        this.other = other;
      }

      public ItemWithDependencies(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command; 
      }

      public ItemWithDependencies()
      {
      }
    }

    public class OtherItem
    {
    }
  }
}