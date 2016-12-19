using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cirrus.SysInfo
{
  public class Disk
  {
    public Disk ()
    {
    } // public Disk ()


    public long GetFreeSpace (string driveName)
    {
      foreach (DriveInfo drive in DriveInfo.GetDrives ())
        if (drive.IsReady && drive.Name == driveName)
          return drive.TotalFreeSpace;

      return -1;
    } // public long GetFreeSpace (string driveName)


    public long GetTotalSize (string driveName)
    {
      foreach (DriveInfo drive in DriveInfo.GetDrives ())
        if (drive.IsReady && drive.Name == driveName)
          return drive.TotalSize;

      return -1;
    } // public long GetTotalSize (string driveName)

  }
}