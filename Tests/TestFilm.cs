//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestFilm.cs
//Version: 20160514

using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestFilm
  {
    [TestMethod]
    public void CreateFilm()
    {
      IFilm metadata = new Film();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveFilm()
    {
      IFilm metadata = new Film();
      metadata.Clear();
      metadata.Id = "11";
      metadata.ReferenceId = "testFilm";
      metadata.Duration = "10:20:30.1234567".ToNullableTimeSpan(FilmMetadata.DEFAULT_DURATION_FORMAT);
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadFilm()
    {
      SaveFilm();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.cxml"))
      {
        IFilm metadata = (IFilm)new Film().Load("testFilm", reader, null);
        Assert.AreEqual("testFilm", metadata.ReferenceId);
        Assert.AreEqual("10:20:30.1234567", metadata.Duration.ToString(FilmMetadata.DEFAULT_DURATION_FORMAT));
      }
    }

  }
}
