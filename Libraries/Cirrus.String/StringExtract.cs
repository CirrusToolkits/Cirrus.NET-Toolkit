using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirrus.String
{
  public class StringExtract
  {
    public string Left (string param, int length)
    {
      //we start at 0 since we want to get the characters starting from the
      //left and with the specified length and assign it to a variable

      string result = param.Substring (0, length);

      return result;
    } // public class StringExtract


    public string Right (string param, int length)
    {
      //start at the index based on the length of the sting minus
      //the specified length and assign it a variable

      string result = param.Substring (param.Length - length, length);

      return result;
    } // public string Right (string param, int length)


    public string Mid (string param, int startIndex, int length)
    {
      //start at the specified index in the string and get N number of
      //characters depending on the length and assign it to a variable

      string result = param.Substring (startIndex, length);

      return result;
    } // public string Mid (string param, int startIndex, int length)


    public string Mid (string param, int startIndex)
    {
      //start at the specified index and return all characters after it
      //and assign it to a variable

      string result = param.Substring (startIndex);

      return result;
    } // public string Mid (string param, int startIndex)

  }
}