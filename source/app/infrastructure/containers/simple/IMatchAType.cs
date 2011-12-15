using System;

namespace app.infrastructure.containers.simple
{
  public interface IMatchAType
  {
    bool matches(Type type);
  }
}