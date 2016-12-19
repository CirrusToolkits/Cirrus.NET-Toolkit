using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cirrus.Net.HTML
{
  public class HTMLlib
  {
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// PURPOSE:
    /// Includes an HTML file in a web page.
    /// 
    /// PARAMETERS:
    /// filename (in) - Filename with HTML content to include with web page.
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public void IncludeHTML (string filename)
    {
      string path = HttpContext.Current.Server.MapPath ("./" + filename);
      string content = System.IO.File.ReadAllText (path);

      HttpContext.Current.Response.Write (content);
    }

  } // public class HTMLlib
} // namespace Cirrus.Net.HTML