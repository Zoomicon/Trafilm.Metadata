//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestScene.cs
//Version: 20160514

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
    public void CreateScene()
    {
      IScene metadata = new Scene();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveScene()
    {
      IScene metadata = new Scene();
      metadata.Clear();
      metadata.Id = "22";
      metadata.ReferenceId = "testFilm.testScene";
      metadata.FilmReferenceId = "testFilm";
      metadata.StartTime = "10:20:30.12".ToNullableTimeSpan(SceneMetadata.DEFAULT_POSITION_FORMAT);
      metadata.Duration = "0:2:5.12".ToNullableTimeSpan(SceneMetadata.DEFAULT_DURATION_FORMAT);
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testScene.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadScene()
    {
      SaveScene();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testScene.cxml"))
      {
        IScene metadata = (IScene)new Scene().Load("testFilm.testScene", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testScene", metadata.ReferenceId);
        Assert.AreEqual("10:20:30.12", metadata.StartTime.ToString(SceneMetadata.DEFAULT_POSITION_FORMAT));
        Assert.AreEqual("0:02:05.12", metadata.Duration.ToString(SceneMetadata.DEFAULT_DURATION_FORMAT));
      }
    }

  }
}
