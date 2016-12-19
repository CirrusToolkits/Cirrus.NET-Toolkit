using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.Math
{
  class Series
  {
    public static bool IsPalindrome (long n)
    {
      string st = Convert.ToString (n);

      return st == (new string (st.Reverse ().ToArray ()));
    } // public static bool IsPalindrome (long n)

  }
}