using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Calendar
{
  class DateValidation
  {
    private const string BAD_DATE = "01/01/0001 12:00:00 AM";


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Checks if sDate is a valid date and/or time string. It can validate either a 
    /// date or time on its own.
    ///
    /// The function tries to convert a date/time string to a DateTime object using
    /// the TryParse method. If it succeeds, TryParse will return the current date, if
    /// it fails (due to it being an invalid date/time) it will return
    /// "01/01/0001 12:00:00 AM".
    /// </summary>
    /// 
    /// <local>
    ///   <param name="sDate" dir="in">date and/or time</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="true">date and time are valid</return>
    ///   <return Value="false">date and time are not valid</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool IsValidDate (string sDate)
    {
      DateTime sResult;

      DateTime.TryParse (sDate, out sResult);

      return (sResult.ToString () != BAD_DATE);
    } // public bool IsValidDate (string sDate, out string sResult)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Checks if sDate is a valid date and/or time string. It can validate either a 
    /// date or time on its own. The date must be later than the current date.
    ///
    /// The function tries to convert a date/time string to a DateTime object using
    /// the TryParse method. If it succeeds, TryParse will return the current date, if
    /// it fails (due to it being an invalid date/time) it will return
    /// "01/01/0001 12:00:00 AM".
    /// </summary>
    /// 
    /// <local>
    ///   <param name="sDate" dir="in">date and/or time</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="true">date and time are valid</return>
    ///   <return Value="false">date and time are not valid</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool IsValidDateNow (string sDate)
    {
      DateTime sResult;
      bool bValidDateString;
      bool bValidDate = false;

      DateTime.TryParse (sDate, out sResult);
      bValidDateString = (sResult.ToString () != BAD_DATE);

      if (bValidDateString)
        bValidDate = (DateTime.Now < sResult);

      return bValidDate;
    } // public bool IsValidDateNow (string sDate)

  }
}
