using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.Math
{
  class Geometry
  {
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// A triangular number or triangle number counts the objects that can form an equilateral
    /// triangle, as in the diagram on the right. The nth triangle number is the number of dots 
    /// composing a triangle with n dots on a side, and is equal to the sum of the n natural 
    /// numbers from 1 to n.
    /// </summary>
    /// <param name="n">Largest triangle number to calculate up to.</param>
    /// <returns></returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public static List<long> GetTriangleNumbers (long n)
    {
      List<long> triangles = new List<long> ();
      long value = 0;
      int i = 1;

      do
      {
        value += i++;
        triangles.Add (value);
      } while (value < n);

      return triangles;
    } // public static List<long> GetTriangleNumbers (long n)

  }
}