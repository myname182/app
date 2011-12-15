using System;

namespace app.infrastructure.containers.simple
{
  public interface ICreateASingleDependency
  {
    object create();
    bool can_create(Type type);
  }
}