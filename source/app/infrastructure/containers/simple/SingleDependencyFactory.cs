using System;

namespace app.infrastructure.containers.simple
{
  public class SingleDependencyFactory:ICreateASingleDependency
  {
    public object create()
    {
      throw new NotImplementedException();
    }

    public bool can_create(Type type)
    {
      throw new NotImplementedException();
    }
  }
}