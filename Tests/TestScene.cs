//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestScene.cs
//Version: 20160513

using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

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
      metadata.StartTime = "10:20:30.12".ToNullableTimeSpan(SceneMetadata.DEFAULT_POSITION_FORMAT);
      metadata.Duration = "02:05.12".ToNullableTimeSpan(SceneMetadata.DEFAULT_DURATION_FORMAT);
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
