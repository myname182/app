using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.infrastructure;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using app.infrastructure.logging.simple;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class Startup
  {
    static IList<ICreateASingleDependency> all_dependencies;
    static FactoryMissingExceptionFactory factory_missing_exception_factory;
    static ItemCreationExceptionFactory item_creation_exception_factory;
    static IFetchDependencies container;

    public static void run()
    {
      all_dependencies = new List<ICreateASingleDependency>();

      factory_missing_exception_factory =
        type => new NotImplementedException("There is no factory registered that can create {0}".format(type.Name));
      item_creation_exception_factory =
        (inner, type) =>
          new NotImplementedException("There was an error attempting to create a {0}".format(type.Name), inner);

      container = new SimpleContainer(
        new DependencyFactories(all_dependencies,
                                factory_missing_exception_factory),
        item_creation_exception_factory);

      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;

      populate_all_dependency_factories();
    }

    static void add_dependency<Implementation>()
    {
      add_dependency<Implementation,Implementation>();
    }

    static void add_dependency<Contract,Implementation>()
    {
      add_factory_for<Contract>(new AutomaticDependencyFactory(typeof(Implementation), new GreediestCtorSelection(), container));
    }

    static void add_dependency<Dependency>(Dependency instance)
    {
      add_factory_for<Dependency>(new BasicDependencyFactory(() => instance));
    }

    static void add_factory_for<Contract>(ICreateADependency factory)
    {
      all_dependencies.Add(new SingleDependencyFactory(TypeCriteria<Contract>(),
                                                       factory));
    }
    static void populate_all_dependency_factories()
    {
      add_dependency(container);
      add_dependency<ICreateControllerRequests, StubRequestFactory>();
      add_dependency<IProcessRequests, FrontController>();
      add_dependency<IFindCommands, CommandRegistry>();
      add_dependency<IEnumerable<IProcessASingleRequest>, StubCommands>();
      add_dependency<IProcessASingleRequest, StubMissingCommand>();
      add_dependency<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
      add_dependency<GetTheCurrentHttpContext>(() => HttpContext.Current);
      add_dependency<GetDepartmentProducts>();
      add_dependency<GetTheMainDepartments>();
      add_dependency<GetDepartmentsInDepartment>();
      add_dependency<IDisplayReports,WebFormDisplayEngine>();
      add_dependency<ICreateWebFormViewsToDisplayReports,WebFormViewFactory>();
      add_dependency<IFindPathsToWebForms,StubPagePathRegistry>();
      add_dependency<CreateLoggingWriter>(() => Console.Out);
      add_dependency(LoggingFormats.simple);
      add_dependency<ICreateLoggers,TextWriterLoggerFactory>();
    }

    static TypeMatchesSpecificType TypeCriteria<SomeType>()
    {
      return new TypeMatchesSpecificType(typeof(SomeType));
    }
  }
}