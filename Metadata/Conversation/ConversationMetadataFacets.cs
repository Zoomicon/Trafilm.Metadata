//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ConversationMetadataFacets.cs
//Version: 20160530

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public static class ConversationMetadataFacets
  {

    #region --- Constants ---

    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";

    public const string FACET_START_TIME = "Start time (h:m:s)";
    public const string FACET_DURATION = "Duration (h:m:s)";

    public const string FACET_L1_LANGUAGE_PRESENT = "L1 language present";
    public const string FACET_L2_LANGUAGE_PRESENT = "L2 language present";

    public const string FACET_SPEAKING_CHARACTERS_COUNT = "Speaking characters: count";
    public const string FACET_L3ST_SPEAKING_CHARACTERS_COUNT = "L3ST-speaking characters: count";

    //Calculatable from L3STinstances//

    public const string FACET_L3ST_LANGUAGES_COUNT = "L3ST languages: count";
    public const string FACET_L3ST_LANGUAGES = "L3ST languages";

    public const string FACET_L3ST_LANGUAGE_TYPES_COUNT = "L3ST language types: count";
    public const string FACET_L3ST_LANGUAGE_TYPES = "L3ST language types";

    public const string FACET_L3ST_INSTANCE_COUNT = "L3ST-instances: count";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_START_TIME, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L1_LANGUAGE_PRESENT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L2_LANGUAGE_PRESENT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_SPEAKING_CHARACTERS_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from L3STinstances//

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGES_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_INSTANCE_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}