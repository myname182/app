using System;

namespace app.tasks.startup
{
  public delegate ICreateStartupChains StartupChainBuilderFactory(Type step);
}