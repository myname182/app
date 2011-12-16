using System;
using System.Reflection;
using System.Linq;

namespace app.infrastructure.containers
{
  public class GreediestCtorSelection : IPickTheCtorForAType
  {
    public ConstructorInfo get_applicable_ctor_on(Type type)
    {
      return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
    }
  }
}