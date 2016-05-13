//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: SceneMetadata.cs
//Version: 20160514

using Metadata.CXML;
using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class SceneMetadata : TrafilmMetadata, ISceneMetadata
  {

    #region --- Constants ---

    public const string DEFAULT_POSITION_FORMAT = "g";
    public const string DEFAULT_DURATION_FORMAT = "g";

    #endregion

    #region --- Properties ---

    public string FilmReferenceId { get; set; }

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? Duration { get; set; }

    public bool L1languagePresent { get; set; }
    public bool L2languagePresent { get; set; }

    public string SpeakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3
    public string L3speakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3

    //Calculatable from Utterances//

    public int L3languagesCount { get; set; }
    public string[] L3languages { get; set; }

    public int L3languageTypesCount { get; set; }
    public string[] L3languageTypes { get; set; }

    public int UtteranceCount { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";

      StartTime = null;
      Duration = null;

      L1languagePresent = true; //this is the most usual case
      L2languagePresent = true; //this is the most usual case

      SpeakingCharactersCount = ""; //can take values like 1, 2, 3, more than 3
      L3speakingCharactersCount = ""; //can take values like 1, 2, 3, more than 3

      L3languagesCount = 0;
      L3languages = new string[] { };

      L3languageTypesCount = 0;
      L3languageTypes = new string[] { };

      UtteranceCount = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_FILM_REFERENCE_ID);

      StartTime = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_START_TIME).ToNullableTimeSpan(DEFAULT_POSITION_FORMAT);
      Duration = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_DURATION).ToNullableTimeSpan(DEFAULT_DURATION_FORMAT);

      L1languagePresent = facets.CXMLFacetBoolValue(SceneMetadataFacets.FACET_L1_LANGUAGE_PRESENT);
      L2languagePresent = facets.CXMLFacetBoolValue(SceneMetadataFacets.FACET_L2_LANGUAGE_PRESENT);

      SpeakingCharactersCount = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT); //e.g. 1, 2, 3, more than 3
      L3speakingCharactersCount = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_L3_SPEAKING_CHARACTERS_COUNT); //e.g. 1, 2, 3, more than 3

      L3languagesCount = int.Parse(facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_L3_LANGUAGES_COUNT));
      L3languages = facets.CXMLFacetStringValues(SceneMetadataFacets.FACET_L3_LANGUAGES);

      L3languageTypesCount = int.Parse(facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_L3_LANGUAGE_TYPES_COUNT));
      L3languageTypes = facets.CXMLFacetStringValues(SceneMetadataFacets.FACET_L3_LANGUAGE_TYPES);

      UtteranceCount = int.Parse(facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_UTTERANCE_COUNT));

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeSceneFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_START_TIME, StartTime.ToString(DEFAULT_POSITION_FORMAT)));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_DURATION, Duration.ToString(DEFAULT_DURATION_FORMAT)));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L1_LANGUAGE_PRESENT, L1languagePresent.ToString())); //this will give True/False (not Yes/No)
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L2_LANGUAGE_PRESENT, L2languagePresent.ToString())); //this will give True/False (not Yes/No)

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT, SpeakingCharactersCount));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_SPEAKING_CHARACTERS_COUNT, L3speakingCharactersCount));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_LANGUAGES_COUNT, L3languagesCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_LANGUAGES, L3languages));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_LANGUAGE_TYPES_COUNT, L3languageTypesCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_LANGUAGE_TYPES, L3languageTypes));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_UTTERANCE_COUNT, UtteranceCount.ToString()));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeSceneFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_START_TIME, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L1_LANGUAGE_PRESENT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L2_LANGUAGE_PRESENT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_SPEAKING_CHARACTERS_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_LANGUAGES_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_LANGUAGE_TYPES_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_LANGUAGE_TYPES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_UTTERANCE_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}