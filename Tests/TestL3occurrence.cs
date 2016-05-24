//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestL3occurrence.cs
//Version: 20160513

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestL3occurrence
  {
    [TestMethod]
    public void CreateL3occurrence()
    {
      IL3occurrence metadata = new L3occurrence();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveL3occurrence()
    {
      IL3occurrence metadata = new L3occurrence();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testConversation.testL3occurrence";
      metadata.FilmReferenceId = "testFilm";
      metadata.ConversationReferenceId = "testFilm.testConversation";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.testL3occurrence.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadL3occurrence()
    {
      SaveL3occurrence();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.testL3occurrence.cxml"))
      {
        IL3occurrence metadata = (IL3occurrence)new L3occurrence().Load("testFilm.testConversation.testL3occurrence", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ConversationReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3occurrence", metadata.ReferenceId);
      }
    }

  }
}
