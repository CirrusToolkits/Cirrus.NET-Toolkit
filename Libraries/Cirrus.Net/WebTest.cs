using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Net
{
  public class WebTest
  {
    public bool IsOnline (string website)
    {
      WebRequest request = WebRequest.Create ("http://" + website);

      bool result = true;

      try
      {
        WebResponse response = request.GetResponse ();

        response.Close ();
      }

      catch (Exception e)
      {
        result = false;
      }

      return result;
    }
  }
}