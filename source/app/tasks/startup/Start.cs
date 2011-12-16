using System;
using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public static class Start
  {
    public static StartupChainBuilderFactory factory_resolver = delegate
    {
      throw new NotImplementedException("We need to come back here once we have a real chain builder to created");
    };

    public static ICreateStartupChains by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
      throw new NotImplementedException();
    }

  }
}