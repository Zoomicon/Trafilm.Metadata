//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestFilm.cs
//Version: 20160513

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System;

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
      IFilm metadata = new Film();
      metadata.Clear();
      metadata.Id = "11";
      metadata.ReferenceId = "testFilm";
      metadata.Duration = TimeSpan.Parse("10:20:30");
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void TestLoad()
    {
      TestSave();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.cxml"))
      {
        IFilm metadata = (IFilm)new Film().Load("testFilm", reader, null);
        Assert.AreEqual("testFilm", metadata.ReferenceId);
      }
    }

  }
}
