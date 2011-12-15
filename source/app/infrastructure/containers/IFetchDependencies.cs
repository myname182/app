using System;

namespace app.infrastructure.containers
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
    object an(Type dependency);
  }
}