namespace app.web.core
{
    using System.Collections.Generic;
    using System.Linq;

    public class CommandRegistry:IFindCommands
  {
      IEnumerable<IProcessASingleRequest> request_processors; 

      public CommandRegistry(IEnumerable<IProcessASingleRequest> requestProcessors)
      {
          request_processors = requestProcessors;
      }

      public IProcessASingleRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
      {
          return request_processors.First(x => x.can_process(request));
      }
  }
}