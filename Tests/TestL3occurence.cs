//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestL3occurence.cs
//Version: 20160513

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestL3occurence
  {
    [TestMethod]
    public void CreateL3occurence()
    {
      IL3occurence metadata = new L3occurence();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveL3occurence()
    {
      IL3occurence metadata = new L3occurence();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testConversation.testL3occurence";
      metadata.FilmReferenceId = "testFilm";
      metadata.ConversationReferenceId = "testFilm.testConversation";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.testL3occurence.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadL3occurence()
    {
      SaveL3occurence();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.testL3occurence.cxml"))
      {
        IL3occurence metadata = (IL3occurence)new L3occurence().Load("testFilm.testConversation.testL3occurence", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ConversationReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3occurence", metadata.ReferenceId);
      }
    }

  }
}
