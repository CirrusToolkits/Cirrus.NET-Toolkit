using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Cirrus.Calendar;
using Cirrus.Cryptography;
using Cirrus.Disk;
using Cirrus.Math;
using Cirrus.Net;
using Cirrus.Net.HTML;
using Cirrus.Net.HTMLwriter;
using Cirrus.PDF;
using Cirrus.Randomize;
using Cirrus.String;
using Cirrus.SysInfo;
using Cirrus.Time;
using Cirrus.Windows;

namespace Cirrus.NET_Toolkit
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main ()
    {
      Application.EnableVisualStyles ();
      Application.SetCompatibleTextRenderingDefault (false);
      Application.Run (new Form_Main ());
    }
  }
}
