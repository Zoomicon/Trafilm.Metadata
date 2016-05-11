using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestScene
  {
    [TestMethod]
    public void TestConstructor()
    {
      IScene metadata = new Scene();
    }

    [TestMethod]
    public void TestStorage()
    {
      IScene metadata = new Scene();
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testScene.cxml"))
        metadata.Save(writer);
    }



  }
}
