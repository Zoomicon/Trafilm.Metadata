//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TTinstanceMetadataFacets.cs
//Version: 20160912

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public static class L3TTinstanceMetadataFacets
  {

    #region --- Constants ---

    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";
    public const string FACET_CONVERSATION_REFERENCE_ID = "Conversation Reference Id";
    public const string FACET_L3ST_INSTANCE_REFERENCE_ID = "L3ST-instance Reference Id";

    public const string FACET_FILM_TITLE_TT = "Film Title TT";
    public const string FACET_PRODUCTION_COUNTRIES = "Production countries";

    public const string FACET_L2_LANGUAGE = "L2 language";
    public const string FACET_L2_MODE = "L2 mode"; //dubbed, subtitled

    public const string FACET_DISTRIBUTION_COUNTRIES_TT = "Distribution countries (TT)";
    public const string FACET_YEAR_TT_RELEASED = "Year TT released";
    public const string FACET_BLOCKBUSTER_TT = "Film TT Blockbuster";

    public const string FACET_START_TIME = "Start time (min)"; //Calculatable from L3STinstance
    public const string FACET_DURATION = "Duration (min)"; //Calculatable from L3STinstance

    public const string FACET_L2_SAME_AS_L3ST = "L2 same as L3ST"; //TODO: maybe this can be autocalculated using (L2language == L3STinstance.L3STlanguage) ?

    public const string FACET_L3ST_CONVEYED_AS_L3TT = "L3ST conveyed as L3TT";

    public const string FACET_L3TT_LANGUAGE_TYPE = "L3TT language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3TT_LANGUAGE = "L3TT language";

    public const string FACET_L3TT_CONSTRUCTED_BASED_ON = "L3TT constructed based on";

    public const string FACET_L3TT_AUDIENCE_UNDERSTANDING = "L3TT meant to be understood";
    public const string FACET_L3TT_MESSAGE_UNDERSTANDING = "L3TT message required for understanding";
    public const string FACET_L3TT_MEANING_DECIPHERABLE = "L3TT meaning decipherable";

    public const string FACET_L3TT_SPEAKER_PERFORMANCE = "Quality of L3TT speaker performance";

    public const string FACET_L3TT_MODE = "L3TT mode, written/spoken, diegetic";

    public const string FACET_L3TT_REPRESENTED = "L3TT merely represented";
    public const string FACET_L3TT_REPRESENTATIONS_ORAL = "L3TT merely represented orally";
    public const string FACET_L3TT_REPRESENTATIONS_VISUAL = "L3TT represented: visual";

    public const string FACET_L3TT_FUNCTIONS = "L3TT functions";
    public const string FACET_L3TT_CONVERSATION_FEATURES = "Conversation features for L3TT-instance";

    public const string FACET_L3TT_SOURCES = "L3TT sources";

    //Calculatable from L3STinstance//

    public const string FACET_L3_LANGUAGE_TYPE_CHANGE = "L3 language type change";
    public const string FACET_L3_MODE_CHANGE = "L3 mode change";
    public const string FACET_L3_FUNCTIONS_CHANGE = "L3 functions change";
    public const string FACET_L3_CONVERSATION_FEATURES_CHANGE = "Conversation features for L3-instance change";
    public const string FACET_L3_SOURCES_CHANGE = "L3 sources change";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories(IList<XElement> result = null) //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      if (result == null)
        result = new List<XElement>();

      TrafilmMetadataFacets.GetCXMLFacetCategories_Header(result);

      //

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3ST_INSTANCE_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_FILM_TITLE_TT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L2_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L2_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_DISTRIBUTION_COUNTRIES_TT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_YEAR_TT_RELEASED, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_BLOCKBUSTER_TT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_START_TIME, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false)); //Calculatable from L3STinstance
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_DURATION, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false)); //Calculatable from L3STinstance

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L2_SAME_AS_L3ST, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_LANGUAGE_TYPE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_CONSTRUCTED_BASED_ON, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_AUDIENCE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_MESSAGE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_MEANING_DECIPHERABLE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_SPEAKER_PERFORMANCE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTATIONS_ORAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTATIONS_VISUAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_FUNCTIONS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_CONVERSATION_FEATURES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_SOURCES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from L3STinstance//

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3_LANGUAGE_TYPE_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3_MODE_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3_FUNCTIONS_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3_CONVERSATION_FEATURES_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3_SOURCES_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //

      TrafilmMetadataFacets.GetCXMLFacetCategories_Footer(result);

      return result;
    }

    #endregion

  }

}