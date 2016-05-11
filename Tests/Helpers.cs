using System.IO;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  class Helpers
  {

    #region --- Helpers ---

    public static XmlReader CreateXmlReader(string inputUri)
    {
      try { return XmlReader.Create(inputUri); }
      catch { return null; }
    }

    public static XmlWriter CreateXmlWriter(string outputFile)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputFile))); //create any parent directories needed
      return XmlWriter.Create(outputFile);
    }

    #endregion

  }
}
