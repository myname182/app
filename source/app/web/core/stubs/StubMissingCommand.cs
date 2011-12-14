namespace app.web.core.stubs
{
  public class StubMissingCommand: IProcessASingleRequest
  {
    public void process(IProvideDetailsToCommands request)
    {

    }

    public bool can_process(IProvideDetailsToCommands request)
    {
      return false;
    }
  }
}