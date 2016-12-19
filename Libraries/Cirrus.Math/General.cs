using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.Math
{
  public class General
  {
    public static List<long> GetDivisors (long n)
    {
      List<long> factors = new List<long> ();

      for (int i = 1; i <= n; i++)
        if (n % i == 0)
          factors.Add (i);

      return factors;
    } // public static List<long> GetDivisors (long n)

  }
}