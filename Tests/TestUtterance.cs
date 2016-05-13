//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestUtterance.cs
//Version: 20160513

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestUtterance
  {
    [TestMethod]
    public void TestConstructor()
    {
      IUtterance metadata = new Utterance();
    }

    [TestMethod]
    public void TestSave()
    {
      IUtterance metadata = new Utterance();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testScene.testUtterance";
      metadata.FilmReferenceId = "testFilm";
      metadata.SceneReferenceId = "testFilm.testScene";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testScene.testUtterance.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      TestSave();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testScene.testUtterance.cxml"))
      {
        IUtterance metadata = (IUtterance)new Utterance().Load("testFilm.testScene.testUtterance", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testScene", metadata.SceneReferenceId);
        Assert.AreEqual("testFilm.testScene.testUtterance", metadata.ReferenceId);
      }
    }

  }
}
