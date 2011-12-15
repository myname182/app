using System;

namespace app.infrastructure
{
  public interface IGetTheTypeThatCalledMe
  {
    Type resolve();
  }
}