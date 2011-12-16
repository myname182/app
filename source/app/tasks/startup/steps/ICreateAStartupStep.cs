using System;

namespace app.tasks.startup.steps
{
  public interface ICreateAStartupStep
  {
    IRunAStartupStep create_step_from(Type step_type);
  }
}