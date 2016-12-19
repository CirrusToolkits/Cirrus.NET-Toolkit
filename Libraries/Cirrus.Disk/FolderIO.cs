using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Cirrus.Disk
{
  public class FolderIO
  {
    public void CopyDirectory (string source, string destination)
    {
      // Create directory if doesn't exist.

      if (!Directory.Exists (destination))
        Directory.CreateDirectory (destination);

      // Copy files from the source directory to the destination directory.

      string [] sysEntries = Directory.GetFileSystemEntries (source);

      foreach (string sysEntry in sysEntries)
      {
        string fileName = Path.GetFileName (sysEntry);
        string targetPath = Path.Combine (destination, fileName);

        if (Directory.Exists (sysEntry))
          CopyDirectory (sysEntry, targetPath);

        else
          File.Copy (sysEntry, targetPath, true);
      } // foreach (string sysEntry in sysEntries)
    } // public void CopyDirectory (string source, string destination)


    public long DirSize (DirectoryInfo d)
    {
      long Size = 0;

      // Add file sizes.

      FileInfo [] fis = d.GetFiles ();

      foreach (FileInfo fi in fis)
        Size += fi.Length;

      // Add subdirectory sizes.

      DirectoryInfo [] dis = d.GetDirectories ();

      foreach (DirectoryInfo di in dis)
        Size += DirSize (di);

      return (Size);
    } // public static long DirSize (DirectoryInfo d)


    public bool isDir (string sDir)
    {
      return Directory.Exists (sDir) && !File.Exists (sDir);
    } // public static bool isDir (string sDir)


    public bool isFile (string sFile)
    {
      return !Directory.Exists (sFile) && File.Exists (sFile);
    } // public static bool isFile (string sFile)


    public virtual bool isFileLocked (FileInfo file)
    {
      FileStream stream = null;

      try
      {
        stream = file.Open (FileMode.Open, FileAccess.ReadWrite, FileShare.None);
      }
      catch (IOException)
      {
        //the file is unavailable because it is:
        //still being written to
        //or being processed by another thread
        //or does not exist (has already been processed)
        return true;
      }
      finally
      {
        if (stream != null)
          stream.Close ();
      }

      //file is not locked
      return false;
    } // public virtual bool isFileLocked (FileInfo file)

  }
}