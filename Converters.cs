//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Converters.cs
//Version: 20160502

using System;
using System.Globalization;

namespace Trafilm.Metadata
{

  public static class Converters
  {

    #region --- Extension Methods ---

    public static int? ToNullableInt(this string value)
    {
      if (String.IsNullOrWhiteSpace(value))
        return null;
      else
        return int.Parse(value);
    }

    //

    public static TimeSpan ToTimeSpan(this string value, string format)
    {
      return TimeSpan.ParseExact(value, format, CultureInfo.InvariantCulture);
    }

    public static TimeSpan? ToNullableTimeSpan(this string value, string format)
    {
      if (String.IsNullOrWhiteSpace(value))
        return null;
      else
        return value.ToTimeSpan(format);
    }

    public static string ToString(this TimeSpan? value, string format)
    {
      return (value != null) ? value.Value.ToString() : ""; //do not use value.ToString(), will do infinite loop
    }

    #endregion

  }

}