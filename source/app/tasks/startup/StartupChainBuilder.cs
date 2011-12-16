using System;
using System.Collections.Generic;
using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public class StartupChainBuilder : ICreateStartupChains
  {
    public IList<Type> all_steps;

    public StartupChainBuilder(IList<Type> all_steps, Type first_step)
    {
      this.all_steps = all_steps;
      add(first_step);
    }

    void add(Type step)
    {
      all_steps.Add(step);
    }

    public ICreateStartupChains followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
        List<Type> new_list = new List<Type>(all_steps);
      return new StartupChainBuilder(new_list, typeof(AStartupStep));
      throw new NotImplementedException();
    }
  }
}