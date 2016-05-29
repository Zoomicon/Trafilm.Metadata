//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Diff.cs
//Version: 20160529

using System;
using System.Collections.Generic;
using System.Linq;

namespace Trafilm.Metadata.Utils
{

  public static class Diff
  {

    #region --- Constants ---

    public const string DEFAULT_PREFIX_ADDED = "+ ";
    public const string DEFAULT_PREFIX_REMOVED = "- ";
    public const string DEFAULT_INFIX_CHANGED = " -> ";

    #endregion

    #region --- Methods --

    public static string GetDifference(string a, string b, string infixChanged = DEFAULT_INFIX_CHANGED)
    {
      if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
        return "";

      return (a == b) ? TrafilmMetadata.VALUE_NONE : a + infixChanged + b;
    }

    public static string[] GetDifferences(string a, string b, string prefixAdded = DEFAULT_PREFIX_ADDED, string prefixRemoved = DEFAULT_PREFIX_REMOVED)
    {
      return GetDifferences(new string[] { a }, new string[] { b }, prefixAdded, prefixRemoved);
    }

    public static string[] GetDifferences(string[] a, string[] b, string prefixAdded = DEFAULT_PREFIX_ADDED, string prefixRemoved = DEFAULT_PREFIX_REMOVED)
    {
      if (a == null)
      {

        if (b == null)
          return new string[] { };

        return b.Select(s => prefixAdded + s).ToArray();
      }
      else //if (a != null)
      {
        if (b == null)
          return b.Where(s => (s != null)).Select(s => prefixRemoved + s).ToArray();

        var result = new List<string>();

        foreach (string s in a)
          if ((s != null) && !b.Contains(s)) //assuming we have handled (b == null) above
            result.Add(prefixRemoved + s);

        foreach (string s in b) //assuming we have handled (b == null) above
          if ((s != null) && !a.Contains(s)) //assuming we have handled (a == null) above
            result.Add(prefixAdded + s);

        if (result.Count == 0)
          result.Add(TrafilmMetadata.VALUE_NONE);

        return result.ToArray();
      }
    }

    #endregion

  }
}
