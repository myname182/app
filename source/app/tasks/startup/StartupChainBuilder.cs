using System;
using System.Collections.Generic;
using app.tasks.startup.steps;

namespace app.tasks.startup
{
    using app.infrastructure.containers;

    public class StartupChainBuilder : ICreateStartupChains
  {
    public IList<Type> all_steps;

      private ICreateAStartupStep startup_step;

     public StartupChainBuilder(IList<Type> all_steps, Type first_step, ICreateAStartupStep startupStep)
      {
        this.all_steps = all_steps;
          startup_step = startupStep;
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
        startup_step.create_step_from(typeof(AStartupStep)).run();

        foreach (var step in all_steps)
        {
            startup_step.create_step_from(step).run();
        }
    }

    public ICreateStartupChains followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep
    {
      return new StartupChainBuilder(new List<Type>(all_steps), typeof(AStartupStep), Container.fetch.an<ICreateAStartupStep>());
    }
  }
}