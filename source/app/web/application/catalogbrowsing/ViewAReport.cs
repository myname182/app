using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewAReport<ReportModel, Query> : ISupportAStory where Query : IQueryToFindA<ReportModel>, new()
  {
    IDisplayReports display_engine;
    Query query;

    public ViewAReport(IDisplayReports display_engine)
    {
      this.display_engine = display_engine;
      this.query = new Query();
    }

    public ViewAReport() : this(new WebFormDisplayEngine())
    {
    }

    public void process(IProvideDetailsToCommands request)
    {
      display_engine.display(query.run_using(request));
    }
  }
}