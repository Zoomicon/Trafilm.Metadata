//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestConversation.cs
//Version: 20161007

using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestConversation
  {

    #region --- Constants ---

    private const int TEST_START_TIME = 10; //min
    private const string TEST_DURATION = "A. 1-20"; //sec

    #endregion


    #region --- Methods ---

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
      metadata.StartTime = TEST_START_TIME;
      metadata.Duration = TEST_DURATION;
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
        Assert.AreEqual(TEST_START_TIME, metadata.StartTime);
        Assert.AreEqual(TEST_DURATION, metadata.Duration);
      }
    }

    #endregion
  }
}
