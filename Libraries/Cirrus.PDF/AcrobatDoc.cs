using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.PDF
{
  public class AcrobatDoc
  {
    // Code from http://stackoverflow.com/questions/969027/check-adobe-reader-is-installed-c.

    public List<string> GetInstalledReaderVersions ()
    {
      List<string> versions = new List<string> ();
      RegistryKey adobe = Registry.LocalMachine.OpenSubKey ("Software").OpenSubKey ("Adobe");

      if (null == adobe)
      {
        var policies = Registry.LocalMachine.OpenSubKey ("Software").OpenSubKey ("Policies");

        if (null == policies)
        {
          versions.Add ("");
          return versions;
        }

        adobe = policies.OpenSubKey ("Adobe");
      }

      if (adobe != null)
      {
        RegistryKey acroRead = adobe.OpenSubKey ("Acrobat Reader");

        if (acroRead != null)
        {
          string [] acroReadVersions = acroRead.GetSubKeyNames ();

          foreach (string versionNumber in acroReadVersions)
          {
            versions.Add (versionNumber);
          }
        }
      }

      return versions;
    } // static List<string> GetInstalledReaderVersions ()


    public string GetPath ()
    {
      string path = Registry.GetValue (@"HKEY_CLASSES_ROOT\Software\Adobe\Acrobat\Exe", string.Empty, string.Empty).ToString ();

      // Return path after deleting " around string.

      return path.Replace ("\"", "");
    } // public string GetPath ()
  }
}