//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: FilmMetadataFacets.cs
//Version: 20160525

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public static class FilmMetadataFacets
  {

    #region --- Properties ---

    public const string FACET_TITLE_ES = "Title in Spanish";
    public const string FACET_TITLE_CA = "Title in Catalan";
    //...

    public const string FACET_DURATION = "Duration (h:m:s.f)";

    public const string FACET_DIRECTORS = "Directors";
    public const string FACET_SCRIPTWRITERS = "Scriptwriters";

    public const string FACET_PRODUCTION_COUNTRIES = "Production countries";
    public const string FACET_PRODUCTION_COMPANIES = "Production companies";

    public const string FACET_BOX_OFFICE = "Box office";
    public const string FACET_YEAR = "Year";

    public const string FACET_L1_LANGUAGE = "L1/Source language";

    public const string FACET_YEAR_TRANSLATED = "Year translated";
    public const string FACET_L2_DUBBED_LANGUAGES = "L2-Dubbed languages";
    public const string FACET_L2_SUBTITLED_LANGUAGES = "L2-Subtitled languages";

    //Calculatable from Conversations//

    public const string FACET_CONVERSATION_COUNT = "Conversations: count";
    public const string FACET_CONVERSATIONS_DURATION = "Conversations: duration (h:m:s.f)";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_ES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_CA, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      //...

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DIRECTORS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SCRIPTWRITERS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_BOX_OFFICE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_YEAR, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_L1_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_YEAR_TRANSLATED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_L2_DUBBED_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_L2_SUBTITLED_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from Conversations//

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_CONVERSATION_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion
  }

}