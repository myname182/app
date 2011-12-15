using System;

namespace app.infrastructure.containers.simple
{
  public interface ICreateASingleDependency : ICreateADependency
  {
    bool can_create(Type type);
  }
}