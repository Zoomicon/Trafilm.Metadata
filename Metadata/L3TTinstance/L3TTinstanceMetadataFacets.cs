//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TTinstanceMetadataFacets.cs
//Version: 20160614

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

    public const string FACET_L2_LANGUAGE = "L2 language";
    public const string FACET_L2_MODE = "L2 mode"; //dubbed, subtitled

    public const string FACET_L2_SAME_AS_L3ST = "L2 same as L3ST"; //TODO: maybe this can be autocalculated using (L2language == L3STinstance.L3STlanguage) ?

    public const string FACET_L3ST_CONVEYED_AS_L3TT = "L3ST conveyed as L3TT";

    public const string FACET_L3TT_LANGUAGE_TYPE = "L3TT language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3TT_LANGUAGE = "L3TT language";

    public const string FACET_L3TT_CONSTRUCTED_BASED_ON = "L3TT constructed based on";

    public const string FACET_L3TT_AUDIENCE_UNDERSTANDING = "L3TT meant to be understood";
    public const string FACET_L3TT_MESSAGE_UNDERSTANDING = "L3TT required for understanding";
    public const string FACET_L3TT_MEANING_DECIPHERABLE = "L3TT meaning decipherable";

    public const string FACET_L3TT_SPEAKER_PERFORMANCE = "L3TT speaker performance";

    public const string FACET_L3TT_MODE = "L3TT mode";

    public const string FACET_L3TT_REPRESENTED = "L3TT represented";
    public const string FACET_L3TT_REPRESENTATIONS_ORAL = "L3TT represented: oral";
    public const string FACET_L3TT_REPRESENTATIONS_VISUAL = "L3TT represented: visual";

    public const string FACET_L3TT_FUNCTIONS = "L3TT functions";

    public const string FACET_L3TT_SOURCES = "L3TT sources";

    //Calculatable from L3STinstance//

    public const string FACET_L3ST_LANGUAGE_TYPE_CHANGE = "L3ST language type change";
    public const string FACET_L3ST_MODE_CHANGE = "L3ST mode change";
    public const string FACET_L3ST_FUNCTIONS_CHANGE = "L3ST functions change";
    public const string FACET_L3ST_SOURCES_CHANGE = "L3ST sources change";

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

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L2_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L2_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

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

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3TT_SOURCES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from L3STinstance//

      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3ST_MODE_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3ST_FUNCTIONS_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3TTinstanceMetadataFacets.FACET_L3ST_SOURCES_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //

      TrafilmMetadataFacets.GetCXMLFacetCategories_Footer(result);

      return result;
    }

    #endregion

  }

}