 using System;
 using Machine.Specifications;
 using app.infrastructure.containers;
 using app.infrastructure.containers.simple;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyFactoriesProvider))]  
  public class DependencyFactoriesProviderSpecs
  {
    public abstract class concern : Observes<ICreateDependencyFactories,
                                      DependencyFactoriesProvider>
    {
        
    }

   
    public class when_creating_a_dependency_factory : concern
    {
      public class to_automatically_create_an_item
      {
        Establish c = () =>
        {
          the_type = typeof(int);
          ctor_picker = depends.on<IPickTheCtorForAType>();
          container = depends.on<IFetchDependencies>();

        };

        Because b = () =>
          result = sut.create_factory_to_automatically_create(the_type);


        It should_create_an_automatic_factory_configured_correctly = () =>
        {
          var item = result.ShouldBeAn<AutomaticDependencyFactory>();
          item.type_to_create.ShouldEqual(the_type);
          item.ctor_picker.ShouldEqual(ctor_picker);
          item.container.ShouldEqual(container);
        };

        static ICreateADependency result;
        static Type the_type;
        static IPickTheCtorForAType ctor_picker;
        static IFetchDependencies container;
      }
      public class to_return_an_instance  
      {
        Establish c = () =>
        {
          the_item = new object();
        };

        Because b = () =>
          result = sut.create_factory_for_instance(the_item);


        It should_return_a_basic_factory_configured_correctly = () =>
        {
          var item = result.ShouldBeAn<BasicDependencyFactory>();
          item.create().ShouldEqual(the_item);
        };

        static ICreateADependency result;
        static object the_item;
      }
        
    }
  }
}
