namespace app.web.core
{
  public class RequestCommand : IProcessASingleRequest
  {
    RequestCriteria criteria;
    ISupportAStory feature;

    public RequestCommand(RequestCriteria criteria, ISupportAStory feature)
    {
      this.criteria = criteria;
      this.feature = feature;
    }

    public void process(IProvideDetailsToCommands request)
    {
      feature.process(request);
    }

    public bool can_process(IProvideDetailsToCommands request)
    {
      return criteria(request);
    }
  }
}