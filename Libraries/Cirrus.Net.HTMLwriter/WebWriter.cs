using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cirrus.Net.HTMLwriter
{
  public class WebWriter
  {
    private string m_HTMLfile;


    public WebWriter ()
    {
    }


    public WebWriter (string outputFile)
    {
      CreateFile (outputFile, "");
    }


    public WebWriter (string outputFile, string title)
    {
      CreateFile (outputFile, title);
    }


    ~WebWriter ()
    {
      Close ();
    }


    public string AddMultilineTextBreaks (string text)
    {
      return text.Replace ("\r\n", "<br />");
    }


    public void Close ()
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("  </body>");
        w.WriteLine ("</html>");
      }
    }


    public void CreateFile (string outputFile, string title)
    {
      m_HTMLfile = outputFile;

      using (TextWriter w = new StreamWriter (outputFile))
      {
        w.WriteLine ("<!DOCTYPE html>");
        w.WriteLine ("");
        w.WriteLine ("<html>");
        w.WriteLine ("  <head>");
        w.WriteLine ("    <title>{0}</title>", title);
        w.WriteLine ("  </head>");
        w.WriteLine ("");
        w.WriteLine ("  <body>");
      }
    }


    public void Custom (string html)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine (html);
      }
    }


    public void EndTag (string tag)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("    </{0}>", tag);
      }
    }


    public void LineBreak ()
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("    <br />");
      }
    }


    public void StartTag (string tag)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("    <{0}>", tag);
      }
    }


    public void Write (string text)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("{0}", text);
      }
    }


    public void Write (string text, string font)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("<span style='font: {1}'>{0}</span>", text, font);
      }
    }


    public void Write (string text, string style, string weight)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("<span style='font-style: {1}; font-weight: {2}'>{0}</span>", text, style, weight);
      }
    }


    public void WriteLine ()
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("");
      }
    }


    public void WriteLine (string text)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("    <p>{0}</p>", text);
      }
    }


    public void WriteLine (string text, string tag)
    {
      using (StreamWriter w = File.AppendText (m_HTMLfile))
      {
        w.WriteLine ("    <{1}>{0}</{1}>", text, tag);
      }
    }  

  }
}