using System;

namespace app.infrastructure.containers.simple
{
  public interface ICreateDependencyFactories
  {
    ICreateADependency create_factory_to_automatically_create(Type type);
    ICreateADependency create_factory_for_instance(object instance);
  }
}