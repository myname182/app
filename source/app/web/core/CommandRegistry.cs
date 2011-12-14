using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessASingleRequest> commands;
    IProcessASingleRequest special_case;

    public CommandRegistry(IEnumerable<IProcessASingleRequest> commands, IProcessASingleRequest specialCase)
    {
      this.commands = commands;
      special_case = specialCase;
    }

    public CommandRegistry():this(Stub.with<StubCommands>(),Stub.with<StubMissingCommand>())
    {
    }

    public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
    {
      return commands.FirstOrDefault(x => x.can_process(request)) ?? special_case;
    }
  }
}
