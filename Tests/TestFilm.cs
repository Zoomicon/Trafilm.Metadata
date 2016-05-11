using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestFilm
  {
    [TestMethod]
    public void TestConstructor()
    {
      IFilm metadata = new Film();
    }

    [TestMethod]
    public void TestStorage()
    {
      IFilm metadata = new Film();
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.cxml"))
        metadata .Save(writer);
    }



  }
}
