//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestL3TToccurrence.cs
//Version: 20160527

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestL3TToccurrence
  {
    [TestMethod]
    public void CreateL3TToccurrence()
    {
      IL3TToccurrence metadata = new L3TToccurrence();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveL3TToccurrence()
    {
      IL3TToccurrence metadata = new L3TToccurrence();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testConversation.testL3SToccurrence.testL3TToccurrence";
      metadata.FilmReferenceId = "testFilm";
      metadata.ConversationReferenceId = "testFilm.testConversation";
      metadata.L3SToccurrenceReferenceId = "testFilm.testConversation.testL3SToccurrence";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.testL3SToccurrence.testL3TToccurrence.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadL3TToccurrence()
    {
      SaveL3TToccurrence();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.testL3SToccurrence.testL3TToccurrence.cxml"))
      {
        IL3TToccurrence metadata = (IL3TToccurrence)new L3TToccurrence().Load("testFilm.testConversation.testL3SToccurrence.testL3TToccurrence", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ConversationReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3SToccurrence", metadata.L3SToccurrenceReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3SToccurrence.testL3TToccurrence", metadata.ReferenceId);
      }
    }

  }
}
