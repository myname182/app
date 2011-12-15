using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.aspnet.stubs
{
  public class StubPagePathRegistry : IFindPathsToWebForms
  {
    public string get_path_to_page_that_can_display<ReportModel>()
    {
      IDictionary<Type,string> paths = new Dictionary<Type, string>();
      paths.Add(typeof(IEnumerable<ProductItem>),"ProductBrowser");
      paths.Add(typeof(IEnumerable<DepartmentItem>),"DepartmentBrowser");

      return string.Format("~/views/{0}.aspx", paths[typeof(ReportModel)]);
    }
  }
}