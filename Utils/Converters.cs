//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Converters.cs
//Version: 20160516

using System;
using System.Globalization;

namespace Trafilm.Metadata.Utils
{

  public static class Converters
  {

    #region --- Extension Methods --

    public static int? ToNullableInt(this string value)
    {
      try
      {
        return (String.IsNullOrWhiteSpace(value)) ? (int?)null : int.Parse(value);
      }
      catch
      {
        return null;
      }
    }

    //

    public static string FixTime(this string value)
    {
      int count = 0;
      foreach (char c in value)
        if (c == ':')
          count++;

      for (int i = 0; i < 2 - count; i++)
        value = "0:" + value;

      return value;
    }

    public static TimeSpan ToTimeSpan(this string value, string format) //throws exceptions 
    {
      return TimeSpan.ParseExact(value.FixTime(), format, CultureInfo.InvariantCulture);
    }

    public static TimeSpan? ToNullableTimeSpan(this string value, string format)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(value))
          return null;
        else
          return value.ToTimeSpan(format);
      }
      catch
      {
        return null;
      }
    }

    public static string ToString(this TimeSpan? value, string format)
    {
      try
      {
        return (value == null) ? "" : ((TimeSpan)value).ToString(format, CultureInfo.InvariantCulture); //don't forget to cast to (TimeSpan), else infinite recursion is caused
      }
      catch
      {
        return "";
      }
    }

    #endregion

  }

}