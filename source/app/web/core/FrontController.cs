namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
      private IFindCommands command_registry;

      public FrontController(IFindCommands commandRegistry)
      {
          this.command_registry = commandRegistry;
      }

      public void process(IProvideDetailsToCommands request)
      {
         var command = command_registry.get_the_command_that_can_process(request);
          command.process(request);
      }
  }
}