using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cirrus.Net
{
  class CPing
  {
    public string IP;

    private string m_Reply_IP;
    private long m_RoundTripTime;
    private int m_TTL;                               // time to live
    private bool m_DontFragment;
    private int m_BufferSize;


    public bool PingIP ()
    {
      bool bSuccess = false;

      Ping pingSender = new Ping ();
      PingOptions options = new PingOptions ();

      // Use the default Ttl value which is 128, but change the fragmentation behavior.

      options.DontFragment = true;

      // Create a buffer of 32 bytes of data to be transmitted. 

      string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
      byte [] buffer = Encoding.ASCII.GetBytes (data);
      int timeout = 120;

      PingReply reply = pingSender.Send (IP, timeout, buffer, options);

      if (reply.Status == IPStatus.Success)
      {
        m_Reply_IP = reply.Address.ToString ();
        m_RoundTripTime = reply.RoundtripTime;
        m_TTL = reply.Options.Ttl;
        m_DontFragment = reply.Options.DontFragment;
        m_BufferSize = reply.Buffer.Length;

        bSuccess = true;
      }

      return bSuccess;
    } // public void PingIP ()

  }
}