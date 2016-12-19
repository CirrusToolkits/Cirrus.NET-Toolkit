using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Cryptography
{
  class SecurePassword
  {
    public string GeneratePassword (string st)
    {
      byte [] data = System.Text.Encoding.ASCII.GetBytes (st);
      data = new System.Security.Cryptography.SHA256Managed ().ComputeHash (data);
      String hash = System.Text.Encoding.ASCII.GetString (data);

      return hash;
    }

  }
}