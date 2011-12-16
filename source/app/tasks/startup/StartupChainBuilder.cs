using System;
using System.Collections.Generic;

namespace app.tasks.startup
{
    using app.tasks.startup.steps;

    public class StartupChainBuilder : ICreateStartupChains
  {
    IList<Type> all_steps;

    public StartupChainBuilder(IList<Type> all_steps, Type first_step)
    {
      this.all_steps = all_steps;
      all_steps.Add(first_step);
    }

      public void followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep
      {
         all_steps.Add(typeof(AStartupStep));
      }
  }
}