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
    public void TestSave()
    {
      Save("test");
    }

    public static void Save(string key)
    {
      IFilm metadata = new Film();
      metadata.Id = key;
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      Save("test");
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.cxml"))
        new Film().Load("test", reader, null);
    }

  }
}
