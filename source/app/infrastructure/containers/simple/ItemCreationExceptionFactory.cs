using System;

namespace app.infrastructure.containers.simple
{
  public delegate Exception ItemCreationExceptionFactory(Exception inner,Type type_that_could_not_be_created);
}