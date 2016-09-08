//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestConversation.cs
//Version: 20160906

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestConversation
  {
    [TestMethod]
    public void CreateConversation()
    {
      IConversation metadata = new Conversation();
      metadata.Clear();
    }

    [TestMethod]
    public void SaveConversation()
    {
      IConversation metadata = new Conversation();
      metadata.Clear();
      metadata.Id = "22";
      metadata.ReferenceId = "testFilm.testConversation";
      metadata.FilmReferenceId = "testFilm";
      metadata.StartTime = 10;
      metadata.Duration = 20;
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testFilm.testConversation.cxml"))
        metadata.Save(writer);
    }

    [TestMethod]
    public void LoadConversation()
    {
      SaveConversation();
      using (XmlReader reader = Helpers.CreateXmlReader(@"testFilm.testConversation.cxml"))
      {
        IConversation metadata = (IConversation)new Conversation().Load("testFilm.testConversation", reader, null);
        Assert.AreEqual("testFilm", metadata.FilmReferenceId);
        Assert.AreEqual("testFilm.testConversation", metadata.ReferenceId);
        Assert.AreEqual(10, metadata.StartTime);
        Assert.AreEqual(20, metadata.Duration);
      }
    }

  }
}
