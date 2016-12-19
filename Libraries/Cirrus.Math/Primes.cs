using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.Math
{
  class Primes
  {
    public static long CountPrimeFactors (long n)
    {
      List<long> factors = new List<long> ();

      factors = GetPrimeFactors (n);

      return factors.Count ();
    }


    public static long GetMaxPrimeFactor (long n)
    {
      List<long> factors = new List<long> ();

      factors = GetPrimeFactors (n);

      if (factors == null)
        return 0;

      else
        return factors.Max ();
    } // public long GetMaxPrimeFactor (long n)


    public static List<long> GetPrimeFactors (long n)
    {
      List<long> factors = new List<long> ();

      if (IsPrime (n))
        factors = null;

      else
      {
        long i = 2;

        while (!IsPrime (n))
        {
          while (n % i != 0)
            i++;

          factors.Add (i);

          n = n / i;
        }

        factors.Add (n);
      }

      return factors;
    } // public static List<long> GetPrimeFactors (long n)


    public static bool IsPrime (long n)
    {
      long mid = n / 2;
      bool prime = true;

      if (n < 2)
        return false;

      for (long i = 2; i <= mid; i++)
        if (n % i == 0)
        {
          prime = false;
          break;
        }

      return prime;
    } // public bool IsPrime (long n)

  }
}