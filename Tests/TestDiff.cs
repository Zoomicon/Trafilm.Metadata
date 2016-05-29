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
      Assert.AreEqual("a to b", Diff.GetDifference("a", "b", infixChanged: " to "));

      CollectionAssert.AreEqual(new string[] { "None" }, Diff.GetDifferences("a", "a"));
      CollectionAssert.AreEqual(new string[] { "- a", "+ b"}, Diff.GetDifferences("a", "b"));
      CollectionAssert.AreEqual(new string[] { "Removed a", "Added b" }, Diff.GetDifferences("a", "b", prefixAdded: "Added ", prefixRemoved: "Removed "));
    }

    [TestMethod]
    public void DiffStringArrays()
    {
      CollectionAssert.AreEqual(new string[] { "None" }, Diff.GetDifferences(new string[] { "a", "b", "c" }, new string[] { "c", "a", "b" }));
      CollectionAssert.AreEqual(new string[] { "- a", "- c", "+ d" }, Diff.GetDifferences(new string[] { "a", "b", "c" }, new string[] { "d", "b" }));
      CollectionAssert.AreEqual(new string[] { "Removed a", "Removed c", "Added d" }, Diff.GetDifferences(new string[] { "a", "b", "c" }, new string[] { "d", "b" }, prefixAdded: "Added ", prefixRemoved: "Removed "));
    }

  }
}
