using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.infrastructure.containers.simple;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ContainerRegistration))]
  public class ContainerRegistrationSpecs
  {
    public abstract class concern : Observes<IRegisterItemsInTheContainer,
                                      ContainerRegistration>
    {
    }

    public class when_registering_an_item : concern
    {
      public class by_contract
      {
        Establish c = () =>
        {
          items = new List<ICreateASingleDependency>();
          factory = fake.an<ICreateADependency>();
          dependency_factory_provider = depends.on<ICreateDependencyFactories>();

          dependency_factory_provider.setup(x => x.create_factory_to_automatically_create(typeof(TheItem)))
            .Return(factory);

          depends.on(items);
        };

        Because b = () =>
          sut.register<TheItem>();

        It should_register_the_item_using_the_correct_type_criteria_and_factory = () =>
        {
          var item = items.First().ShouldBeAn<SingleDependencyFactory>();
          item.type_criteria.ShouldBeAn<TypeMatchesSpecificType>().type_to_match.ShouldEqual(typeof(TheItem));
          item.real_factory.ShouldEqual(factory);
        };

        static IList<ICreateASingleDependency> items;
        static ICreateADependency factory;
        static ICreateDependencyFactories dependency_factory_provider;
      }

      public class by_contract_and_implementation
      {
        Establish c = () =>
        {
          items = new List<ICreateASingleDependency>();
          factory = fake.an<ICreateADependency>();
          dependency_factory_provider = depends.on<ICreateDependencyFactories>();

          dependency_factory_provider.setup(x => x.create_factory_to_automatically_create(typeof(TheItem)))
            .Return(factory);

          depends.on(items);
        };

        Because b = () =>
          sut.register<TheContract, TheItem>();

        It should_register_the_item_using_the_correct_type_criteria_and_factory = () =>
        {
          var item = items.First().ShouldBeAn<SingleDependencyFactory>();
          item.type_criteria.ShouldBeAn<TypeMatchesSpecificType>().type_to_match.ShouldEqual(typeof(TheContract));
          item.real_factory.ShouldEqual(factory);
        };

        static IList<ICreateASingleDependency> items;
        static ICreateADependency factory;
        static ICreateDependencyFactories dependency_factory_provider;
      }

      public class by_instance
      {
        Establish c = () =>
        {
          items = new List<ICreateASingleDependency>();
          item = new TheItem();
          factory = fake.an<ICreateADependency>();
          dependency_factory_provider = depends.on<ICreateDependencyFactories>();

          dependency_factory_provider.setup(x => x.create_factory_for_instance(item))
            .Return(factory);

          depends.on(items);
        };

        Because b = () =>
          sut.register(item);

        It should_register_the_item_using_the_correct_type_criteria_and_factory = () =>
        {
          var item = items.First().ShouldBeAn<SingleDependencyFactory>();
          item.type_criteria.ShouldBeAn<TypeMatchesSpecificType>().type_to_match.ShouldEqual(typeof(TheItem));
          item.real_factory.ShouldEqual(factory);
        };

        static IList<ICreateASingleDependency> items;
        static ICreateADependency factory;
        static ICreateDependencyFactories dependency_factory_provider;
        static TheItem item;
      }
    }

    public class when_its_iterator_is_requested:concern
    {
      Establish c = () =>
      {
        original_list = depends.on<IList<ICreateASingleDependency>>();
        iterator = new List<ICreateASingleDependency>().GetEnumerator();
        original_list.setup(x => x.GetEnumerator()).Return(iterator);
      };
         
      Because b = () =>
        result = sut;

      It should_return_the_iterator_from_its_list_of_factories = () =>
        result.GetEnumerator().ShouldEqual(iterator);


      static IEnumerable<ICreateASingleDependency> result;
      static IList<ICreateASingleDependency> original_list;
      static IEnumerator<ICreateASingleDependency> iterator;
    }
    public class TheItem : TheContract
    {
    }

    public interface TheContract
    {
    }
  }
}