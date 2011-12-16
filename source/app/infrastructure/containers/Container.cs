using System;

namespace app.infrastructure.containers
{
  public class Container
  {
    public static ContainerFacadeResolver facade_resolver = () => fetch;

    public static IFetchDependencies fetch
    {
      get { return facade_resolver(); }
    }
  }
}