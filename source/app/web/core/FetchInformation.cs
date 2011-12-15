namespace app.web.core
{
  public interface IQueryToFindA<out ReportModel>
  {
    ReportModel run_using(IProvideDetailsToCommands request);
  }
}