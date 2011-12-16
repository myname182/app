using System;
using System.Collections.Generic;
using System.IO;
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

	  public static void run()
		{
			all_dependencies = new List<ICreateASingleDependency>();

	    factory_missing_exception_factory = type => new NotImplementedException("There is no factory registered that can create {0}".format(type.Name));
	    item_creation_exception_factory = (inner, type) => new NotImplementedException("There was an error attempting to create a {0}".format(type.Name), inner);

	    IFetchDependencies container = new SimpleContainer(
				new DependencyFactories(all_dependencies,
										factory_missing_exception_factory),
				item_creation_exception_factory);

			ContainerFacadeResolver resolver = () => container;
			Container.facade_resolver = resolver;

			populate_all_dependency_factories();

		}

		static void populate_all_dependency_factories()
		{
		  all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(ICreateControllerRequests)),
		                                                   new BasicDependencyFactory(() => Stub.with<StubRequestFactory>())));
      all_dependencies.Add(new SingleDependencyFactory(TypeCriteria<IFindCommands>(),
        new BasicDependencyFactory(() => new CommandRegistry(Container.fetch.an<IEnumerable<IProcessASingleRequest>>(),
          Stub.with<StubMissingCommand>()))));
			all_dependencies.Add(new SingleDependencyFactory(TypeCriteria<IProcessRequests>(), new BasicDependencyFactory(() => new FrontController(Container.fetch.an<IFindCommands>()))));
		  all_dependencies.Add(
		    new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(IEnumerable<IProcessASingleRequest>)),
		                                new BasicDependencyFactory(() => Stub.with<StubCommands>())));


		  PageFactory factory = BuildManager.CreateInstanceFromVirtualPath;
		  all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(PageFactory)),
		                                                   new BasicDependencyFactory(() => factory)));

		  GetTheCurrentHttpContext current_context = () => HttpContext.Current;

		  all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(GetTheCurrentHttpContext)),
		                                                   new BasicDependencyFactory(() => current_context)));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(GetDepartmentProducts)),
        new BasicDependencyFactory(() => new GetDepartmentProducts())));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(GetTheMainDepartments)),
        new BasicDependencyFactory(() => new GetTheMainDepartments())));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(GetDepartmentsInDepartment)),
        new BasicDependencyFactory(() => new GetDepartmentsInDepartment())));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(IDisplayReports)),
        new BasicDependencyFactory(() => new WebFormDisplayEngine(Container.fetch.an<GetTheCurrentHttpContext>(),
          Container.fetch.an<ICreateWebFormViewsToDisplayReports>()))));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(ICreateWebFormViewsToDisplayReports)),
        new BasicDependencyFactory(() => new WebFormViewFactory(Container.fetch.an<IFindPathsToWebForms>(),
          Container.fetch.an<PageFactory>()))));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(IFindPathsToWebForms)),
        new BasicDependencyFactory(() => Stub.with<StubPagePathRegistry>())));

		  CreateLoggingWriter logging_writer = () => Console.Out;
      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(CreateLoggingWriter)),
        new BasicDependencyFactory(() => logging_writer)));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(LoggingMessageFormatter)),
        new BasicDependencyFactory(() => LoggingFormats.simple)));

      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(ICreateLoggers)),
        new BasicDependencyFactory(() => new TextWriterLoggerFactory(Container.fetch.an<CreateLoggingWriter>(),
          Container.fetch.an<LoggingMessageFormatter>()))));

		}

	    private static TypeMatchesSpecificType TypeCriteria<SomeType>()
	    {
	        return new TypeMatchesSpecificType(typeof(SomeType));
	    }
	}
}