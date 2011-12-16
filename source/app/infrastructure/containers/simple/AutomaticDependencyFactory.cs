using System;
using System.Linq;

namespace app.infrastructure.containers.simple
{
  public class AutomaticDependencyFactory : ICreateADependency
  {
    public Type type_to_create;
    public IPickTheCtorForAType ctor_picker;
    public IFetchDependencies container;

    public AutomaticDependencyFactory(Type type_to_create, IPickTheCtorForAType ctor_picker, IFetchDependencies container)
    {
      this.type_to_create = type_to_create;
      this.ctor_picker = ctor_picker;
      this.container = container;
    }

    public object create()
    {
      var ctor = ctor_picker.get_applicable_ctor_on(type_to_create);
      var ctor_params = ctor.GetParameters().Select(x => container.an(x.ParameterType));
      return ctor.Invoke(ctor_params.ToArray());
    }
  }
}