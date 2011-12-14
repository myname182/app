using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
    using System;

  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessASingleRequest> commands;
    IProcessASingleRequest special_case;

    public CommandRegistry(IEnumerable<IProcessASingleRequest> commands, IProcessASingleRequest specialCase)
    {
        this.commands = commands;
        special_case = specialCase;
    }

    public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
    {
        try
        {
            return commands.First(x => x.can_process(request));
        }
        catch(InvalidOperationException)
        {
            return special_case;
        }
    }
  }
}