using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.String
{
  class IsType
  {
    public bool IsDate (string sDate)
    {
      bool bDate = true;

      try
      {
        DateTime dt = DateTime.Parse (sDate);
      }

      catch
      {
        bDate = false;
      }

      return bDate;
    } // public bool IsDate (string inputDate)

  }
}