using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessASingleRequest> commands;

    public CommandRegistry(IEnumerable<IProcessASingleRequest> commands)
    {
      this.commands = commands;
    }

    public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
    {
      return commands.First(x => x.can_process(request));
    }
  }
}