//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestL3TTinstance.cs
//Version: 20161007

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestL3TTinstance
  {

    #region --- Methods ---

    [TestMethod]
    public void CreateL3TTinstance()
    {
      IL3TTinstance metadata = new L3TTinstance();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveL3TTinstance()
    {
      IL3TTinstance metadata = new L3TTinstance();
      metadata.Clear();
      metadata.Id = "33";
      metadata.ReferenceId = "testFilm.testConversation.testL3STinstance.testL3TTinstance";
      metadata.FilmReferenceId = "testFilm";
      metadata.ConversationReferenceId = "testFilm.testConversation";
      metadata.L3STinstanceReferenceId = "testFilm.testConversation.testL3STinstance";
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.testL3STinstance.testL3TTinstance.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadL3TTinstance()
    {
      SaveL3TTinstance();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.testL3STinstance.testL3TTinstance.cxml"))
      {
        IL3TTinstance metadata = (IL3TTinstance)new L3TTinstance().Load("testFilm.testConversation.testL3STinstance.testL3TTinstance", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ConversationReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3STinstance", metadata.L3STinstanceReferenceId);
        Assert.AreEqual("testFilm.testConversation.testL3STinstance.testL3TTinstance", metadata.ReferenceId);
      }
    }

    #endregion

  }
}
