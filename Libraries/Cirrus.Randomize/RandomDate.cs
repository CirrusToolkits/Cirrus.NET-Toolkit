using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cirrus.String;


namespace Cirrus.Randomize
{
  public class RandomDate
  {
    public string GenerateRandomDate (int iDigits)
    {
      DateTime dtNow = DateTime.Now;           // current date and time

      string sRandomDate;

      int iYear = dtNow.Year;                  // current year
      int iMonth = dtNow.Month;                // current month
      int iDay = dtNow.Day;                    // current day
      int iHour = dtNow.Hour;                  // current hour
      int iMinute = dtNow.Minute;              // current minute
      int iSecond = dtNow.Second;              // current second

      // Pad dates to format as 2 digit number.

      string sYear = iYear.ToString ();
      string sMonth = iMonth.ToString ().PadLeft (2, '0');
      string sDay = iDay.ToString ().PadLeft (2, '0');
      string sHour = iHour.ToString ().PadLeft (2, '0');
      string sMinute = iMinute.ToString ().PadLeft (2, '0');
      string sSecond = iSecond.ToString ().PadLeft (2, '0');

      string sRandom;
      Random rFolder = new Random ((iHour * iMinute) + iSecond);

      sRandom = rFolder.Next ().ToString ();
      StringExtract oRandom = new StringExtract ();
      sRandom = oRandom.Left (sRandom, iDigits);

      // Build random date string.

      sRandomDate = sYear + "-" + sMonth + sDay + "-" + sHour + sMinute + sSecond + "-" + sRandom;

      // Return the order number generated.

      return (sRandomDate);
    } // private string RandomDate ()

  }
}