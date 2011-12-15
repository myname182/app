using System;

namespace app.infrastructure.containers.simple
{
  public class TypeMatchesSpecificType:IMatchAType
  {
    Type type_to_match;

    public TypeMatchesSpecificType(Type type_to_match)
    {
      this.type_to_match = type_to_match;
    }

    public bool matches(Type type)
    {
      return type_to_match == type;
    }
  }
}