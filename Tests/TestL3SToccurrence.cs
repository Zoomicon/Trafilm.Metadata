//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestL3SToccurrence.cs
//Version: 20160525

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestL3SToccurrence
  {
    [TestMethod]
    public void CreateL3SToccurrence()
    {
      IL3SToccurrence metadata = new L3SToccurrence();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveL3SToccurrence()
    {
      IL3SToccurrence metadata = new L3SToccurrence();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testConversation.testL3SToccurrence";
      metadata.FilmReferenceId = "testFilm";
      metadata.ConversationReferenceId = "testFilm.testConversation";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.testL3SToccurrence.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadL3SToccurrence()
    {
      SaveL3SToccurrence();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.testL3SToccurrence.cxml"))
      {
        IL3SToccurrence metadata = (IL3SToccurrence)new L3SToccurrence().Load("testFilm.testConversation.testL3SToccurrence", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ConversationReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3SToccurrence", metadata.ReferenceId);
      }
    }

  }
}
