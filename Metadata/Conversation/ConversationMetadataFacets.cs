﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ConversationMetadataFacets.cs
//Version: 20180510

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public static class ConversationMetadataFacets
  {

    #region --- Constants ---

    //Conversation metadata//

    public const string FACET_FILM_OR_SEASON_TITLE = "Film/Season title";

    public const string FACET_SEASON_EPISODE_NAME = "Season episode name";

    public const string FACET_START_TIME = "Start time (min)";
    public const string FACET_DURATION = "Duration (sec)";

    //public const string FACET_LANGUAGE_SOURCES = "Language sources"; //NOT USED

    //Linked Data: Calculatable from L3STinstances//

    public const string FACET_L3ST_LANGUAGES_COUNT = "L3ST languages: count";
    public const string FACET_L3ST_LANGUAGES = "L3ST languages";

    public const string FACET_L3ST_LANGUAGE_TYPES_COUNT = "L3ST language types: count";
    public const string FACET_L3ST_LANGUAGE_TYPES = "L3ST language types";

    public const string FACET_L3ST_INSTANCE_COUNT = "L3ST-instances: count";

    //Linked Data: References//

    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories(IList<XElement> result = null) //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      if (result == null)
        result = new List<XElement>();

      //Common metadata (header)//

      TrafilmMetadataFacets.GetCXMLFacetCategories_Header(result);

      //Conversation metadata//

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_FILM_OR_SEASON_TITLE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true)); //Calculatable from Film
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_SEASON_EPISODE_NAME, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_START_TIME, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_LANGUAGE_SOURCES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true)); //NOT USED

      //Linked Data: Calculatable from L3STinstances//

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGES_COUNT, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES_COUNT, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_L3ST_INSTANCE_COUNT, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //Common metadata (footer)//

      TrafilmMetadataFacets.GetCXMLFacetCategories_Footer(result);

      //Linked Data: References//

      result.Add(CXML.MakeFacetCategory(ConversationMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      return result;
    }

    #endregion

  }

}