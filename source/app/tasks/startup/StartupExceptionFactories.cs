using System;
using app.infrastructure;
using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
  public class StartupExceptionFactories
  {
    public static ItemCreationExceptionFactory dependency_creation_error = (inner,type) =>
      new NotImplementedException("There was an error attempting to create a {0}".format(type.Name), inner);

    public static FactoryMissingExceptionFactory factory_not_registered = type =>
        new NotImplementedException("There is no factory registered that can create {0}".format(type.Name));
  }
}