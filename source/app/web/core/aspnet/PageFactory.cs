using System;

namespace app.web.core.aspnet
{
  public delegate object PageFactory(string page_path,Type page_type);
}