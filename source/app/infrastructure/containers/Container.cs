using System;

namespace app.infrastructure.containers
{
  public class Container
  {
    public static ContainerFacadeResolver facade_resolver= () =>
    {
      throw new NotImplementedException("This needs to be configured by a startup process");
    };

    public static IFetchDependencies fetch
    {
      get
      {
          return facade_resolver();
      }
    }
  }
}