using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public interface ICreateStartupChains
  {
    void followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep;

  }
}