//Project: Trafilm (http://trafilm.net)
//Filename: SceneMetadata.cs
//Version: 20160503

using Metadata.CXML;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class SceneMetadata : TrafilmMetadata, ISceneMetadata
  {

    #region --- Properties ---

    public string FilmReferenceId { get; set; }

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? Duration { get; set; }

    public bool L1sourceLanguagePresent { get; set; }
    public bool L2translatedLanguagePresent { get; set; }

    public string SpeakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3
    public string L3speakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3

    //Calculatable from Utterances//

    public int L3otherLanguagesCount { get; set; }
    public string[] L3otherLanguages { get; set; }

    public int L3otherTypesCount { get; set; }
    public string[] L3otherTypes { get; set; }

    public int UtteranceCount { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";

      StartTime = null;
      Duration = null;

      L1sourceLanguagePresent = true; //this is the most usual case
      L2translatedLanguagePresent = true; //this is the most usual case

      SpeakingCharactersCount = ""; //can take values like 1, 2, 3, more than 3
      L3speakingCharactersCount = ""; //can take values like 1, 2, 3, more than 3

      L3otherLanguagesCount = 0;
      L3otherLanguages = new string[] { };

      L3otherTypesCount = 0;
      L3otherTypes = new string[] { };

      UtteranceCount = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_FILM_REFERENCE_ID);

      StartTime = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_START_TIME).ToNullableTimeSpan("HH:MM:SS.FF");
      Duration = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_DURATION).ToNullableTimeSpan("MM:SS.FF");

      L1sourceLanguagePresent = facets.CXMLFacetBoolValue(SceneMetadataFacets.FACET_L1_SOURCE_LANGUAGE_PRESENT);
      L2translatedLanguagePresent = facets.CXMLFacetBoolValue(SceneMetadataFacets.FACET_L2_TRANSLATED_LANGUAGE_PRESENT);

      SpeakingCharactersCount = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT); //e.g. 1, 2, 3, more than 3
      L3speakingCharactersCount = facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_L3_SPEAKING_CHARACTERS_COUNT); //e.g. 1, 2, 3, more than 3

      L3otherLanguagesCount = int.Parse(facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_L3_OTHER_LANGUAGES_COUNT));
      L3otherLanguages = facets.CXMLFacetStringValues(SceneMetadataFacets.FACET_L3_OTHER_LANGUAGES);

      L3otherTypesCount = int.Parse(facets.CXMLFacetStringValue(SceneMetadataFacets.FACET_L3_OTHER_TYPES_COUNT));
      L3otherTypes = facets.CXMLFacetStringValues(SceneMetadataFacets.FACET_L3_OTHER_TYPES);

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

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_START_TIME, StartTime.ToString("HH:MM:SS.FF")));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_DURATION, Duration.ToString("MM:SS.FF")));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L1_SOURCE_LANGUAGE_PRESENT, L1sourceLanguagePresent.ToString())); //this will give True/False (not Yes/No)
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L2_TRANSLATED_LANGUAGE_PRESENT, L2translatedLanguagePresent.ToString())); //this will give True/False (not Yes/No)

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT, SpeakingCharactersCount));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_SPEAKING_CHARACTERS_COUNT, L3speakingCharactersCount));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_OTHER_LANGUAGES_COUNT, L3otherLanguagesCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_OTHER_LANGUAGES, L3otherLanguages));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_OTHER_TYPES_COUNT, L3otherTypesCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_L3_OTHER_TYPES, L3otherTypes));

      AddNonNullToList(facets, CXML.MakeStringFacet(SceneMetadataFacets.FACET_UTTERANCE_COUNT, UtteranceCount.ToString()));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeSceneFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: false, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_START_TIME, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L1_SOURCE_LANGUAGE_PRESENT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L2_TRANSLATED_LANGUAGE_PRESENT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_SPEAKING_CHARACTERS_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_OTHER_LANGUAGES_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_OTHER_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_OTHER_TYPES_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_L3_OTHER_TYPES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(SceneMetadataFacets.FACET_UTTERANCE_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}