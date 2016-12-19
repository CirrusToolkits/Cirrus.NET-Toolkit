using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Cryptography
{
  public class Checksums
  {
    public string CalcMD5Checksum (string file)
    {
      using (MD5 md5 = MD5.Create ())
      {
        using (FileStream stream = File.OpenRead (file))
        {
          byte [] checksum = md5.ComputeHash (stream);
          return (BitConverter.ToString (checksum).Replace ("-", string.Empty));
        }
      }
    } // public string CalcMD5Checksum (string file)

  }
}