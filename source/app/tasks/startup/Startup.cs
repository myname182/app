using System;
using System.Collections.Generic;
using app.infrastructure.containers;
using app.infrastructure.containers.simple;
using app.web.core;

namespace app.tasks.startup
{
  public class Startup
  {
    static IList<ICreateASingleDependency> all_dependencies;

    public static void run()
    {
      all_dependencies = new List<ICreateASingleDependency>();

      IFetchDependencies container =
        new SimpleContainer(
          new DependencyFactories(all_dependencies,
                                  type => new NotImplementedException(
                                    string.Format("There is no factory registered that can create {0}", type.Name))),
          (inner, type) =>
            new NotImplementedException(string.Format("There was an error attempting to create a {0}", type.Name), inner));

      ContainerFacadeResolver resolver = () => container;
      Container.facade_resolver = resolver;

      populate_all_dependency_factories();


    }

    static void populate_all_dependency_factories()
    {
      all_dependencies = new List<ICreateASingleDependency>();
      all_dependencies.Add(new SingleDependencyFactory(new TypeMatchesSpecificType(typeof(IProcessRequests)),new BasicDependencyFactory(() => new FrontController(null))));
    }
  }
}