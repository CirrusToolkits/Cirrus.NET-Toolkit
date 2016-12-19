using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cirrus.Time
{
  public class DigitalTimer
  {
    private static DateTime m_StartTime;
    private static DateTime m_EndTime;


    public static void StartTimer ()
    {
      m_StartTime = DateTime.Now;
    }


    public static void EndTimer ()
    {
      m_EndTime = DateTime.Now;
    }


    public static string ShowElapsedTime ()
    {
      return (m_EndTime - m_StartTime).ToString ();
    }

  }
}