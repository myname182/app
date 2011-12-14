namespace app.web.core
{
  public interface IFindCommands
  {
    IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands request);
  }
}