using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace Cirrus.Windows
{
  public class WinServices
  {
    public enum ServiceStatus
    {
      ContinuePending,                // The service has been paused and is about to continue.
      Paused,                         // The service is paused.
      PausePending,                   // The service is in the process of pausing.
      Running,                        // The service is running.
      StartPending,                   // The service is in the process of starting.
      Stopped,                        // The service is not running.
      StopPending                     // The service is in the process of stopping.
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the status of the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public ServiceStatus GetStatus (string serviceName)
    {
      ServiceController sc = new ServiceController (serviceName);
      ServiceStatus status = ServiceStatus.Running;

      sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
      sc.Refresh ();

      if (sc.Status == ServiceControllerStatus.ContinuePending)
        status = ServiceStatus.ContinuePending;

      else if (sc.Status == ServiceControllerStatus.Paused)
        status = ServiceStatus.Paused;

      else if (sc.Status == ServiceControllerStatus.PausePending)
        status = ServiceStatus.PausePending;

      else if (sc.Status == ServiceControllerStatus.Running)
        status = ServiceStatus.Running;

      else if (sc.Status == ServiceControllerStatus.StartPending)
        status = ServiceStatus.StartPending;

      else if (sc.Status == ServiceControllerStatus.Stopped)
        status = ServiceStatus.Stopped;

      else if (sc.Status == ServiceControllerStatus.StopPending)
        status = ServiceStatus.StopPending;

      return status;
    } // public ServiceStatus GetStatus (string serviceName)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the status of the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public ServiceStatus GetStatus (string serviceName, string server)
    {
      ServiceController sc = new ServiceController (serviceName, server);
      ServiceStatus status = ServiceStatus.Running;

      //sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
      sc.Refresh ();

      if (sc.Status == ServiceControllerStatus.ContinuePending)
        status = ServiceStatus.ContinuePending;

      else if (sc.Status == ServiceControllerStatus.Paused)
        status = ServiceStatus.Paused;

      else if (sc.Status == ServiceControllerStatus.PausePending)
        status = ServiceStatus.PausePending;

      else if (sc.Status == ServiceControllerStatus.Running)
        status = ServiceStatus.Running;

      else if (sc.Status == ServiceControllerStatus.StartPending)
        status = ServiceStatus.StartPending;

      else if (sc.Status == ServiceControllerStatus.Stopped)
        status = ServiceStatus.Stopped;

      else if (sc.Status == ServiceControllerStatus.StopPending)
        status = ServiceStatus.StopPending;

      return status;
    } // public ServiceStatus GetStatus (string serviceName, string server)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the status of the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public string GetStatusString (string serviceName)
    {
      ServiceController sc = new ServiceController (serviceName);
      string status = "";

      //sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
      sc.Refresh ();

      if (sc.Status == ServiceControllerStatus.ContinuePending)
        status = ServiceStatus.ContinuePending.ToString ();

      else if (sc.Status == ServiceControllerStatus.Paused)
        status = ServiceStatus.Paused.ToString ();

      else if (sc.Status == ServiceControllerStatus.PausePending)
        status = ServiceStatus.PausePending.ToString ();

      else if (sc.Status == ServiceControllerStatus.Running)
        status = ServiceStatus.Running.ToString ();

      else if (sc.Status == ServiceControllerStatus.StartPending)
        status = ServiceStatus.StartPending.ToString ();

      else if (sc.Status == ServiceControllerStatus.Stopped)
        status = ServiceStatus.Stopped.ToString ();

      else if (sc.Status == ServiceControllerStatus.StopPending)
        status = ServiceStatus.StopPending.ToString ();

      return status;
    } // public ServiceStatus GetStatusString (string serviceName)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Returns the status of the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public string GetStatusString (string serviceName, string server)
    {
      ServiceController sc = new ServiceController (serviceName, server);
      string status = "";

      //sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
      sc.Refresh ();

      if (sc.Status == ServiceControllerStatus.ContinuePending)
        status = ServiceStatus.ContinuePending.ToString ();

      else if (sc.Status == ServiceControllerStatus.Paused)
        status = ServiceStatus.Paused.ToString ();

      else if (sc.Status == ServiceControllerStatus.PausePending)
        status = ServiceStatus.PausePending.ToString ();

      else if (sc.Status == ServiceControllerStatus.Running)
        status = ServiceStatus.Running.ToString ();

      else if (sc.Status == ServiceControllerStatus.StartPending)
        status = ServiceStatus.StartPending.ToString ();

      else if (sc.Status == ServiceControllerStatus.Stopped)
        status = ServiceStatus.Stopped.ToString ();

      else if (sc.Status == ServiceControllerStatus.StopPending)
        status = ServiceStatus.StopPending.ToString ();

      return status;
    } // public ServiceStatus GetStatusString (string serviceName, string server)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Starts the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool StartService (string serviceName)
    {
      try
      {
        ServiceController sc = new ServiceController (serviceName);
        sc.Start ();
        sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
        sc.Refresh ();

        return sc.Status == ServiceControllerStatus.Running;
      }

      catch (Exception ex)
      {
        return false;
      }
    } // public bool StartService (string ServiceName)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Starts the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool StartService (string serviceName, string server)
    {
      try
      {
        ServiceController sc = new ServiceController (serviceName, server);
        sc.Start ();
        sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
        sc.Refresh ();

        return sc.Status == ServiceControllerStatus.Running;
      }

      catch (Exception ex)
      {
        return false;
      }
    } // public bool StartService (string ServiceName, string server)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Stops the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool StopService (string serviceName)
    {
      try
      {
        ServiceController sc = new ServiceController (serviceName);
        sc.Stop ();
        sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
        sc.Refresh ();

        return sc.Status == ServiceControllerStatus.Running;
      }

      catch (Exception ex)
      {
        return false;
      }
    } // public bool StopService (string ServiceName)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Stops the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool StopService (string serviceName, string server)
    {
      try
      {
        ServiceController sc = new ServiceController (serviceName, server);
        sc.Stop ();
        sc.WaitForStatus (ServiceControllerStatus.Running, new TimeSpan (0, 0, 10));
        sc.Refresh ();

        return sc.Status == ServiceControllerStatus.Running;
      }

      catch (Exception ex)
      {
        return false;
      }
    } // public bool StopService (string ServiceName, string server)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Restarts the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool RestartService (string serviceName)
    {
      bool status = true;

      StopService (serviceName);
      StartService (serviceName);

      return status;
    } // public bool RestartServices (string serviceName)


    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Restarts the service.
    /// </summary>
    /// <param name="db">Backed up database.</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public bool RestartService (string serviceName, string server)
    {
      bool status = true;

      StopService (serviceName, server);
      StartService (serviceName, server);

      return status;
    } // public bool RestartServices (string serviceName, string server)

  }
}