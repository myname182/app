using System;

namespace app.infrastructure.containers.simple
{
  public delegate Exception FactoryMissingExceptionFactory(Type type_that_has_no_factory);
}