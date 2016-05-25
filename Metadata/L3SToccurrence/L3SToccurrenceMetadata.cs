//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3SToccurrenceMetadata.cs
//Version: 20160525

using Metadata.CXML;
using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace Trafilm.Metadata
{

  public class L3SToccurrenceMetadata : TrafilmMetadata, IL3SToccurrenceMetadata
  {

    #region --- Constants ---

    public const string DEFAULT_POSITION_FORMAT = "g";
    public const string DEFAULT_DURATION_FORMAT = "g";

    #endregion

    #region --- Properties ---

    public string FilmReferenceId { get; set; }
    public string ConversationReferenceId { get; set; }

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? Duration { get; set; }

    public string L3STlanguageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    public string L3STlanguage { get; set; }

    public string[] L3STconstructedBasedOn { get; set; }

    public string L3STaudienceUnderstanding { get; set; }
    public string L3STmessageUnderstanding { get; set; }
    public string L3STmeaningDecipherable { get; set; }

    public string L3STspeakerPerformance { get; set; }

    public string[] L3STmode { get; set; }

    public string[] L3STrepresented { get; set; }
    public string[] L3STrepresentationsOral { get; set; }
    public string[] L3STrepresentationsVisual { get; set; }

    public string[] L3STfunctions { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";
      ConversationReferenceId = "";

      StartTime = null;
      Duration = null;

      L3STlanguageType = "";
      L3STlanguage = "";

      L3STconstructedBasedOn = new string[] { };

      L3STaudienceUnderstanding = "";
      L3STmessageUnderstanding = "";
      L3STmeaningDecipherable = "";

      L3STspeakerPerformance = "";

      L3STmode = new string[] { };

      L3STrepresented = new string[] { };
      L3STrepresentationsOral= new string[] { };
      L3STrepresentationsVisual = new string[] { };

      L3STfunctions = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_FILM_REFERENCE_ID);
      ConversationReferenceId = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID);

      StartTime = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_START_TIME).ToNullableTimeSpan(DEFAULT_POSITION_FORMAT);
      Duration = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_DURATION).ToNullableTimeSpan(DEFAULT_DURATION_FORMAT);

      L3STlanguageType = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE);
      L3STlanguage = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_L3ST_LANGUAGE);

      L3STconstructedBasedOn = facets.CXMLFacetStringValues(L3SToccurrenceMetadataFacets.FACET_L3ST_CONSTRUCTED_BASED_ON);

      L3STaudienceUnderstanding = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_L3ST_AUDIENCE_UNDERSTANDING);
      L3STmessageUnderstanding = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_L3ST_MESSAGE_UNDERSTANDING);
      L3STmeaningDecipherable = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_L3ST_MEANING_DECIPHERABLE);

      L3STspeakerPerformance = facets.CXMLFacetStringValue(L3SToccurrenceMetadataFacets.FACET_L3ST_SPEAKER_PERFORMANCE);

      L3STmode = facets.CXMLFacetStringValues(L3SToccurrenceMetadataFacets.FACET_L3ST_MODE);

      L3STrepresented = facets.CXMLFacetStringValues(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTED);
      L3STrepresentationsOral = facets.CXMLFacetStringValues(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTATIONS_ORAL);
      L3STrepresentationsVisual = facets.CXMLFacetStringValues(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTATIONS_VISUAL);

      L3STfunctions = facets.CXMLFacetStringValues(L3SToccurrenceMetadataFacets.FACET_L3ST_FUNCTIONS);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeL3SToccurrenceFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, ConversationReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_START_TIME, StartTime.ToString(DEFAULT_POSITION_FORMAT)));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_DURATION, Duration.ToString(DEFAULT_DURATION_FORMAT)));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE, L3STlanguageType));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_LANGUAGE, L3STlanguage));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_CONSTRUCTED_BASED_ON, L3STconstructedBasedOn));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_AUDIENCE_UNDERSTANDING, L3STaudienceUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_MESSAGE_UNDERSTANDING, L3STmessageUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_MEANING_DECIPHERABLE, L3STmeaningDecipherable));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_SPEAKER_PERFORMANCE, L3STspeakerPerformance));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_MODE, L3STmode));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTED, L3STrepresented));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTATIONS_ORAL, L3STrepresentationsOral));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTATIONS_VISUAL, L3STrepresentationsVisual));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3SToccurrenceMetadataFacets.FACET_L3ST_FUNCTIONS, L3STfunctions));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeL3SToccurrenceFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_FILM_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_START_TIME, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_CONSTRUCTED_BASED_ON, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_AUDIENCE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_MESSAGE_UNDERSTANDING, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_MEANING_DECIPHERABLE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_SPEAKER_PERFORMANCE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_MODE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTATIONS_ORAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_REPRESENTATIONS_VISUAL, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(L3SToccurrenceMetadataFacets.FACET_L3ST_FUNCTIONS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}