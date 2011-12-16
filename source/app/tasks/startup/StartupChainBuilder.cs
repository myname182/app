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
      if (already_contains(step)) return;
      all_steps.Add(step);
    }

    bool already_contains(Type step)
    {
      return all_steps.Contains(step);
    }

    public void finish_by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
      throw new NotImplementedException();
    }

    public ICreateStartupChains followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
      return new StartupChainBuilder(new List<Type>(all_steps), typeof(AStartupStep));
    }
  }
}