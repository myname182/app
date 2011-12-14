using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public class DepartmentItem
  {
    public string name { get; set; }
    public IEnumerable<DepartmentItem> departments { get; set; }
  }
}