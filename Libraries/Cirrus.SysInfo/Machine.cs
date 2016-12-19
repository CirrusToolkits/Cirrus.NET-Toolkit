using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Cirrus.SysInfo
{
  public class Machine
  {
    public static string MachineName = System.Environment.MachineName;                 // name of computer
    public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;              // folder where app is installed


    public Machine ()
    {
    } // public Machine ()


    public string GetHostName ()
    {
      return Dns.GetHostName ();
    } // public string GetHostName ()

  }
}
