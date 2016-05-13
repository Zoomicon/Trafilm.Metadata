//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestScene.cs
//Version: 20160513

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System;
using System.Globalization;

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
      metadata.StartTime = TimeSpan.Parse("10:20:30.25");
      metadata.Duration = TimeSpan.ParseExact("2:5.10", SceneMetadata.DEFAULT_TIMESPAN_DURATION_FORMAT, CultureInfo.InvariantCulture);
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
