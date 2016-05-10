//Project: Trafilm (http://trafilm.net)
//Filename: UtteranceMetadata.cs
//Version: 20160510

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class UtteranceMetadata : TrafilmMetadata, IUtteranceMetadata
  {

    #region --- Properties ---

    public string FilmReferenceId { get; set; }
    public string SceneReferenceId { get; set; }

    public string L3type { get; set; } //L3ST, L3TT

    public string LmainLanguage { get; set; } //depending on L3 type this is either the L1ST language or the L2TT language
    public string LmainMode { get; set; } //oral, text (means dubbed, subtitled in L2TT context)

    public bool L2sameAsL3ST { get; set; }
    public bool L3STconveyedAsL3TT { get; set; }

    public string L3languageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    public string L3language { get; set; }

    public string[] L3constructedBasedOn { get; set; }

    public string L3audienceUnderstanding { get; set; }
    public string L3messageUnderstanding { get; set; }
    public string L3meaningDeciphered { get; set; }

    public string L3speakerPerformance { get; set; }

    public string[] L3mode { get; set; } //oral, written (or both)
    public string L3STmodeChange { get; set; } //for L3 type = L3ST this should always be "Not applicable"

    public string[] L3represented { get; set; }
    public string[] L3representationsOral { get; set; }
    public string[] L3representationsVisual { get; set; }

    public string[] L3functions { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";
      SceneReferenceId = "";

      L3type = "";

      LmainLanguage = "";
      LmainMode = "";

      L2sameAsL3ST = false;
      L3STconveyedAsL3TT = false;

      L3languageType = "";
      L3language = "";

      L3constructedBasedOn = new string[] { };

      L3audienceUnderstanding = "";
      L3messageUnderstanding = "";
      L3meaningDeciphered = "";

      L3speakerPerformance = "";

      L3mode = new string[] { };
      L3STmodeChange = "";

      L3represented = new string[] { };
      L3representationsOral= new string[] { };
      L3representationsVisual = new string[] { };

      L3functions = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_FILM_REFERENCE_ID);
      SceneReferenceId = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_SCENE_REFERENCE_ID);

      L3type = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_TYPE);

      LmainLanguage = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L_MAIN_LANGUAGE);
      LmainMode = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L_MAIN_MODE);

      L2sameAsL3ST = facets.CXMLFacetBoolValue(UtteranceMetadataFacets.FACET_L2_SAME_AS_L3ST);
      L3STconveyedAsL3TT = facets.CXMLFacetBoolValue(UtteranceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT);

      L3languageType = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_LANGUAGE_TYPE);
      L3language = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_LANGUAGE);

      L3constructedBasedOn = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_L3_CONSTRUCTED_BASED_ON);

      L3audienceUnderstanding = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_AUDIENCE_UNDERSTANDING);
      L3messageUnderstanding = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_MESSAGE_UNDERSTANDING);
      L3meaningDeciphered = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_MEANING_DECIPHERED);

      L3speakerPerformance = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3_SPEAKER_PERFORMANCE);

      L3mode = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_L3_MODE);
      L3STmodeChange = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_L3ST_MODE_CHANGE); //for L3 type = L3ST this should always be "Not applicable" 

      L3represented = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_L3_REPRESENTED);
      L3representationsOral = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_L3_REPRESENTATIONS_ORAL);
      L3representationsVisual = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_L3_REPRESENTATIONS_VISUAL);

      L3functions = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_L3_FUNCTIONS);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeUtteranceFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_SCENE_REFERENCE_ID, SceneReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_TYPE, L3type));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L_MAIN_LANGUAGE, LmainLanguage));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L_MAIN_MODE, LmainMode));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L2_SAME_AS_L3ST, L2sameAsL3ST.ToString())); //this will give True/False (not Yes/No)
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT, L3STconveyedAsL3TT.ToString())); //this will give True/False (not Yes/No)

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_LANGUAGE_TYPE, L3languageType));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_LANGUAGE, L3language));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_CONSTRUCTED_BASED_ON, L3constructedBasedOn));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_AUDIENCE_UNDERSTANDING, L3audienceUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_MESSAGE_UNDERSTANDING, L3messageUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_MEANING_DECIPHERED, L3meaningDeciphered));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_SPEAKER_PERFORMANCE, L3speakerPerformance));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_MODE, L3mode));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3ST_MODE_CHANGE, L3STmodeChange));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_REPRESENTED, L3represented));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_REPRESENTATIONS_ORAL, L3representationsOral));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_REPRESENTATIONS_VISUAL, L3representationsVisual));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_L3_FUNCTIONS, L3functions));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeUtteranceFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_SCENE_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_TYPE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L_MAIN_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L_MAIN_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L2_SAME_AS_L3ST, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_LANGUAGE_TYPE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_CONSTRUCTED_BASED_ON, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_AUDIENCE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_MESSAGE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_MEANING_DECIPHERED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_SPEAKER_PERFORMANCE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3ST_MODE_CHANGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_REPRESENTED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_REPRESENTATIONS_ORAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_REPRESENTATIONS_VISUAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_L3_FUNCTIONS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}