using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestScene
  {
    [TestMethod]
    public void TestConstructor()
    {
      IScene metadata = new Scene();
    }

    [TestMethod]
    public void TestSave()
    {
      Save("test");
    }

    public static void Save(string key)
    {
      IScene metadata = new Scene();
      metadata.Id = key;
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testScene.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      Save("test");
      using (XmlReader reader = Helpers.CreateXmlReader(@"testScene.cxml"))
        new Scene().Load("test", reader, null);
    }

  }
}
