//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestDiff.cs
//Version: 20160529

using Trafilm.Metadata.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestDiff
  {
    [TestMethod]
    public void DiffStrings()
    {
      Assert.AreEqual("None", Diff.GetDifference("a", "a"));
      Assert.AreEqual("a -> b", Diff.GetDifference("a", "b"));

      CollectionAssert.AreEqual(new string[] { "None" }, Diff.GetDifferences("a", "a"));
      CollectionAssert.AreEqual(new string[] { "- a", "+ b"}, Diff.GetDifferences("a", "b"));
    }

    [TestMethod]
    public void DiffStringArrays()
    {
      CollectionAssert.AreEqual(new string[] { "None" }, Diff.GetDifferences(new string[] { "a", "b", "c" }, new string[] { "c", "a", "b" }));
      CollectionAssert.AreEqual(new string[] { "- a", "- c", "+ d" }, Diff.GetDifferences(new string[] { "a", "b", "c" }, new string[] { "d", "b" }));
    }

  }
}
