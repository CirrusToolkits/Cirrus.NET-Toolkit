using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Calendar
{
  public class MultiCalendar
  {
    /*********************************************************************************************
     * Global Variables
     *********************************************************************************************/

    public enum CalendarType { GREGORIAN, JULIAN, HEBREW, ISLAMIC, ISO8601 };
    public enum CalWeekday { SUNDAY, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY };

    public CalendarType ActiveCalendar;
    public CalWeekday WeekStart;


    /*********************************************************************************************
     * Constructors
     *********************************************************************************************/

    public MultiCalendar ()
    {
      ActiveCalendar = CalendarType.GREGORIAN;
      WeekStart = CalWeekday.SUNDAY;
    }


    /*********************************************************************************************
     * Methods
     *********************************************************************************************/


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the actual day of the month based on its position on the 42 day calendar.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    ///   <parm name="pos" dir="in">Position of day on 42 day calendar.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">The day of the month.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public int GetDay (int year, int month, int pos)
    {
      int day;
      int firstPos = GetFirstDayPos (year, month);
      int lastPos = GetLastDayPos (year, month);

      if ((pos < firstPos) || (pos > lastPos))
        day = 0;

      else
        day = pos - firstPos + 1;

      return day;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the number of days in a month.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">The number of days in the month.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public int GetDaysInMonth (int year, int month)
    {
      return DateTime.DaysInMonth (year, month);
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the number of days in a month.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">The number of days in the month.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public int GetFirstDayOfMonth (int year, int month)
    {
      return GetFirstDayPos (year, month);
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the first day of the month.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">The number of the day of the week.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public int GetFirstDayPos (int year, int month)
    {
      DateTime d = new DateTime (year, month, 1);

      return Convert.ToInt32 (d.DayOfWeek) + 1;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the last day of the month.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">The number of the day of the week.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public int GetLastDayOfMonth (int year, int month)
    {
      int firstDay = GetFirstDayOfMonth (year, month);
      int lastDay = GetDaysInMonth (year, month);

      DateTime d = new DateTime (year, month, lastDay);

      return Convert.ToInt32 (d.DayOfWeek) + 1;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the position of the last day in a month. Position is the number within a 6 week
    /// by 7 day grid, for a total of 42 positions.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">The position of the last day in a 42 day month grid.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public int GetLastDayPos (int year, int month)
    {
      return GetFirstDayOfMonth (year, month) + GetDaysInMonth (year, month) - 1;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the proper name of the month.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="month" dir="in">Month to convert to string name.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="int">Proper name of month.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public string GetMonthName (int month)
    {
      string name;

      switch (month)
      {
        case 1: name = "January"; break;
        case 2: name = "February"; break;
        case 3: name = "March"; break;
        case 4: name = "April"; break;
        case 5: name = "May"; break;
        case 6: name = "June"; break;
        case 7: name = "July"; break;
        case 8: name = "August"; break;
        case 9: name = "September"; break;
        case 10: name = "October"; break;
        case 11: name = "November"; break;
        case 12: name = "December"; break;

        default: name = ""; break;
      }

      return name;
    }


    public string GetMonthName (int year, int day)
    {
      DateTime baseDate = new DateTime (year, 1, 1);
      DateTime currentDate = baseDate.AddDays (day);

      return GetMonthName (currentDate.Month);
    }


    public string GetWeekdayName (int year, int day)
    {
      DateTime baseDate = new DateTime (year, 1, 1);
      DateTime currentDate = baseDate.AddDays (day);

      return currentDate.DayOfWeek.ToString ();
    }


    public string GetCalendarDay (int year, int day)
    {
      DateTime baseDate = new DateTime (year, 1, 1);
      DateTime currentDate = baseDate.AddDays (day);

      return currentDate.Day.ToString ();
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns true if year is a leap year.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check for leap year.</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="bool">True if leap year, false otherwise.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool IsLeapYear (int year)
    {
      return ((year % 4 == 0) || (year % 100 == 0) || (year % 400 == 0));
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns a string containing the month calendar. Month name can be optionally displayed.
    /// </summary>
    /// 
    /// <local>
    ///   <param name="year" dir="in">Year to check.</param>
    ///   <param name="month" dir="in">Month to check.</param>
    ///   <parm name="bool" dir="in">Display month name?</param>
    /// </local>
    /// 
    /// <returns>
    ///   <return Value="string">Calendar for selected month.</return>
    /// </returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public string ShowMonth (int year, int month, bool name)
    {
      int d = 0;
      string st = "";
      string separator = "";

      if (name)
      {
        st = GetMonthName (month);

        for (int i = 1; i <= st.Length; i++)
          separator += "=";

        st += "\r\n" + separator + "\r\n";
      }

      for (int i = 1; i <= 42; i++)
      {
        d = GetDay (year, month, i);

        if (d == 0)
          st += " -- ";

        else
          st += " " + d.ToString ().PadLeft (2) + " ";

        if (i % 7 == 0)
          st += "\r\n";
      }

      return st;
    }

  }
}