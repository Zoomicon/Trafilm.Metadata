//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Helpers.cs
//Version: 20160516

using System.IO;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  class Helpers
  {

    #region --- Constants ---

    public static XmlWriterSettings DEFAULT_XML_WRITER_SETTINGS = new XmlWriterSettings() { Indent = true, IndentChars = "  " };

    #endregion

    #region --- Methods ---

    public static XmlReader CreateXmlReader(string inputUri)
    {
      try { return XmlReader.Create(inputUri); }
      catch { return null; }
    }

    public static XmlWriter CreateXmlWriter(string outputFile)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputFile))); //create any parent directories needed
      return XmlWriter.Create(outputFile, DEFAULT_XML_WRITER_SETTINGS);
    }

    #endregion

  }
}
