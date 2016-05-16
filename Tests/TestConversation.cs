//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestConversation.cs
//Version: 20160516

using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

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
      metadata.StartTime = "10:20:30.12".ToNullableTimeSpan(ConversationMetadata.DEFAULT_POSITION_FORMAT);
      metadata.Duration = "2:5.12".ToNullableTimeSpan(ConversationMetadata.DEFAULT_DURATION_FORMAT);
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
        Assert.AreEqual("10:20:30.12", metadata.StartTime.ToString(ConversationMetadata.DEFAULT_POSITION_FORMAT));
        Assert.AreEqual("0:02:05.12", metadata.Duration.ToString(ConversationMetadata.DEFAULT_DURATION_FORMAT));
      }
    }

  }
}
