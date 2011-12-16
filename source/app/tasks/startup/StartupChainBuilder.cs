﻿using System;
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
        if(!all_steps.Contains(step))
        all_steps.Add(step);
    }

    public ICreateStartupChains followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
      return new StartupChainBuilder(new List<Type>(all_steps), typeof(AStartupStep));
    }
  }
}