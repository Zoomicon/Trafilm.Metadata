//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3STinstanceMetadataFacets.cs
//Version: 20180423

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  //TODO: add "FilmTitle" (calculatable from Conversation)
  //TODO: add "SeriesEpisodeName" (calculatable from Conversation)

  public static class L3STinstanceMetadataFacets
  {

    #region --- Constants ---

    //Linked Data: Calculatable from Conversation//

    public const string FACET_CONVERSATION_START_TIME = "Conversation start time (min)";
    public const string FACET_CONVERSATION_DURATION = "Conversation duration (sec)";

    //Linked Data: Calculatable from Film//

    public const string FACET_L1_LANGUAGE = "Main (L1) language";
    
    //L3STinstance metadata//

    public const string FACET_L3ST_LANGUAGE_TYPE = "L3ST language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3ST_LANGUAGE = "L3ST language";

    public const string FACET_L3ST_CONSTRUCTED_BASED_ON = "L3ST constructed based on";

    public const string FACET_L3ST_AUDIENCE_UNDERSTANDING = "L3ST meant to be understood";
    public const string FACET_L3ST_MESSAGE_UNDERSTANDING = "L3ST message required for understanding";
    public const string FACET_L3ST_MEANING_DECIPHERABLE = "L3ST meaning decipherable";

    public const string FACET_L3ST_SPEAKER_PERFORMANCE = "Quality of L3ST speaker performance";

    public const string FACET_L3ST_MODE = "L3ST mode, written/spoken, diegetic";

    public const string FACET_L3ST_REPRESENTED = "L3ST merely represented";
    public const string FACET_L3ST_REPRESENTATIONS_ORAL = "L3ST merely represented orally";
    public const string FACET_L3ST_REPRESENTATIONS_VISUAL = "L3ST represented: visual";

    public const string FACET_L3ST_FUNCTIONS = "L3ST functions";
    public const string FACET_L3ST_CONVERSATION_FEATURES = "Conversation features for L3ST-instance";

    public const string FACET_L3ST_SOURCES = "L3ST sources";

    //Linked Data: Calculatable from L3TTinstances//

    public const string FACET_L3TT_INSTANCE_COUNT = "L3TT-instances: count";

    //Linked Data: References//

    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";
    public const string FACET_CONVERSATION_REFERENCE_ID = "Conversation Reference Id";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories(IList<XElement> result = null) //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      if (result == null)
        result = new List<XElement>();

      //Common metadata (header)//

      TrafilmMetadataFacets.GetCXMLFacetCategories_Header(result);

      //Linked Data: Calculatable from Conversation//

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_CONVERSATION_START_TIME, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_CONVERSATION_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //Linked Data: Calculatable from Film//

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L1_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //L3STinstance metadata//

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
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_CONVERSATION_FEATURES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3ST_SOURCES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Linked Data: Calculatable from L3TTinstances//

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_L3TT_INSTANCE_COUNT, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //Common metadata (footer)//

      TrafilmMetadataFacets.GetCXMLFacetCategories_Footer(result);

      //Linked Data: References//

      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3STinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      return result;
    }

    #endregion

  }

}