using Trafilm.Metadata.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestUtterance
  {
    [TestMethod]
    public void TestConstructor()
    {
      IUtterance metadata = new Utterance();
    }

    [TestMethod]
    public void TestStorage()
    {
      IUtterance metadata = new Utterance();
      metadata.Clear();
      using (XmlWriter writer = Helpers.CreateXmlWriter(@"testUtterance.cxml"))
        metadata.Save(writer);
    }



  }
}
