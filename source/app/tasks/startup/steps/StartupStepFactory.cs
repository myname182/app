using System;

namespace app.tasks.startup.steps
{
  public class StartupStepFactory : ICreateAStartupStep
  {
    IRegisterItemsInTheContainer registration;

      public StartupStepFactory(IRegisterItemsInTheContainer registration)
      {
          this.registration = registration;
      }
    public IRunAStartupStep create_step_from(Type step_type)
    {
        IRunAStartupStep step = create_step_from(step_type);
        registration.register(step);
        return step;
    }
  }
}