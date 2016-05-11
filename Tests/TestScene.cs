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
      IScene metadata = new Scene();
      metadata.Clear();
      metadata.Id = "22";
      metadata.ReferenceId = "testFilm.testScene";
      metadata.FilmReferenceId = "testFilm";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testScene.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      TestSave();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testScene.cxml"))
      {
        IScene metadata = (IScene)new Scene().Load("testFilm.testScene", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testScene", metadata.ReferenceId);
      }
    }

  }
}
