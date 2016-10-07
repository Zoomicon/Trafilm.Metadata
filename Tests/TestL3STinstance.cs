//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestL3STinstance.cs
//Version: 20161007

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{

  #region --- Methods ---

  [TestClass]
  public class TestL3STinstance
  {
    [TestMethod]
    public void CreateL3STinstance()
    {
      IL3STinstance metadata = new L3STinstance();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveL3STinstance()
    {
      IL3STinstance metadata = new L3STinstance();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testConversation.testL3STinstance";
      metadata.FilmReferenceId = "testFilm";
      metadata.ConversationReferenceId = "testFilm.testConversation";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.testL3STinstance.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadL3STinstance()
    {
      SaveL3STinstance();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.testL3STinstance.cxml"))
      {
        IL3STinstance metadata = (IL3STinstance)new L3STinstance().Load("testFilm.testConversation.testL3STinstance", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ConversationReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3STinstance", metadata.ReferenceId);
      }
    }

    #endregion

  }
}
