using app.infrastructure.containers;

namespace app.web.core
{
  public class ViewAReport<ReportModel, Query> : ISupportAStory where Query : IQueryToFindA<ReportModel>
  {
    IDisplayReports display_engine;
    Query query;

    public ViewAReport(IDisplayReports display_engine,IFetchDependencies container)
    {
      this.display_engine = display_engine;
      this.query = container.an<Query>();
    }

    public void process(IProvideDetailsToCommands request)
    {
      display_engine.display(query.run_using(request));
    }
  }
}