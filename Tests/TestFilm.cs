//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestFilm.cs
//Version: 20160906

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

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
      metadata.Duration = 120;
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
        Assert.AreEqual(120, metadata.Duration);
      }
    }

  }
}
