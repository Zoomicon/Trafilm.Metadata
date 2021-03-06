﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TestConversation.cs
//Version: 20160516

using Trafilm.Metadata.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Trafilm.Metadata.Tests
{
  [TestClass]
  public class TestUtils
  {
    [TestMethod]
    public void FixTime()
    {
      Assert.AreEqual("1:2:3.4", "1:2:3.4".FixTime());
      Assert.AreEqual("0:2:3.4", "2:3.4".FixTime());
      Assert.AreEqual("0:0:3.4", "3.4".FixTime());
    }

  }
}
