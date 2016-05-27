//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Diff.cs
//Version: 20160527

using System;
using System.Collections.Generic;
using System.Linq;

namespace Trafilm.Metadata.Utils
{

  public static class Diff
  {

    #region --- Methods --

    public static string GetDifference(string a, string b)
    {
      if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
        return "";

      return (a == b) ? TrafilmMetadata.VALUE_NONE : a + " -> " + b;
    }

    public static string[] GetDifferences(string[] a, string[] b)
    {
      if (a == null)
      {

        if (b == null)
          return new string[] { };

        return b.Select(s => "+ " + s).ToArray();
      }
      else //if (a != null)
      {
        if (b == null)
          return b.Select(s => "- " + s).ToArray();

        var result = new List<string>();

        foreach (string s in a)
          if (!b.Contains(s)) //assuming we have handled (b == null) above
            result.Add("- " + s);

        foreach (string s in b) //assuming we have handled (b == null) above
          if (!a.Contains(s)) //assuming we have handled (a == null) above
            result.Add("+ " + s);

        if (result.Count == 0)
          result.Add("None");

        return result.ToArray();
      }
    }

    #endregion

  }
}
