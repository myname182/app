using System;
using System.Reflection;

namespace app.infrastructure.containers
{
  public interface IPickTheCtorForAType
  {
    ConstructorInfo get_applicable_ctor_on(Type type);
  }
}