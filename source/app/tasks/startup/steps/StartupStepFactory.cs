using System;

namespace app.tasks.startup.steps
{
  public class StartupStepFactory : ICreateAStartupStep
  {
    public IRunAStartupStep create_step_from(Type step_type)
    {
      throw new NotImplementedException();
    }
  }
}