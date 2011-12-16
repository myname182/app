using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public interface ICreateStartupChains
  {
    ICreateStartupChains followed_by<AStartupStep>() where AStartupStep : IRunAStartupStep;
    void finish_by<AStartupStep>() where AStartupStep : IRunAStartupStep;
  }
}