//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3STinstanceMetadataFacets.cs
//Version: 20160530

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public static class L3STinstanceMetadataFacets
  {

    #region --- Properties ---

    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";
    public const string FACET_CONVERSATION_REFERENCE_ID = "Conversation Reference Id";

    public const string FACET_START_TIME = "Start time (h:m:s.f)";
    public const string FACET_DURATION = "Duration (h:m:s.f)";

    public const string FACET_L1_LANGUAGE = "L1 language"; //Calculatable from Film

    public const string FACET_L3ST_LANGUAGE_TYPE = "L3ST language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3ST_LANGUAGE = "L3ST language";

    public const string FACET_L3ST_CONSTRUCTED_BASED_ON = "L3ST constructed based on";

    public const string FACET_L3ST_AUDIENCE_UNDERSTANDING = "L3ST meant to be understood";
    public const string FACET_L3ST_MESSAGE_UNDERSTANDING = "L3ST required for understanding";
    public const string FACET_L3ST_MEANING_DECIPHERABLE = "L3ST meaning decipherable";

    public const string FACET_L3ST_SPEAKER_PERFORMANCE = "L3ST speaker performance";

    public const string FACET_L3ST_MODE = "L3ST mode";

    public const string FACET_L3ST_REPRESENTED = "L3ST represented";
    public const string FACET_L3ST_REPRESENTATIONS_ORAL = "L3ST represented: oral";
    public const string FACET_L3ST_REPRESENTATIONS_VISUAL = "L3ST represented: visual";

    public const string FACET_L3ST_FUNCTIONS = "L3ST functions";

    //Calculatable from L3TTinstances//

    public const string FACET_L3TT_INSTANCE_COUNT = "L3TT-instances: count";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_START_TIME, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L1_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true)); //Calculatable from Film

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_CONSTRUCTED_BASED_ON, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_AUDIENCE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_MESSAGE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_MEANING_DECIPHERABLE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_SPEAKER_PERFORMANCE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTATIONS_ORAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTATIONS_VISUAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_FUNCTIONS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from L3TTinstances//

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3TT_INSTANCE_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}