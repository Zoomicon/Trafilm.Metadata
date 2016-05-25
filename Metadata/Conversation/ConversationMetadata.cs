//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ConversationMetadata.cs
//Version: 20160525

using Metadata.CXML;
using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class ConversationMetadata : TrafilmMetadata, IConversationMetadata
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
    public string L3STspeakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3

    //Calculatable from L3SToccurrences//

    public int L3STlanguagesCount { get; set; }
    public string[] L3STlanguages { get; set; }

    public int L3STlanguageTypesCount { get; set; }
    public string[] L3STlanguageTypes { get; set; }

    public int L3SToccurrenceCount { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";

      StartTime = null;
      Duration = null;

      L1languagePresent = false;
      L2languagePresent = false;

      SpeakingCharactersCount = ""; //can take values like 1, 2, 3, more than 3
      L3STspeakingCharactersCount = ""; //can take values like 1, 2, 3, more than 3

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      L3STlanguagesCount = 0;
      L3STlanguages = new string[] { };

      L3STlanguageTypesCount = 0;
      L3STlanguageTypes = new string[] { };

      L3SToccurrenceCount = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_FILM_REFERENCE_ID);

      StartTime = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_START_TIME).ToNullableTimeSpan(DEFAULT_POSITION_FORMAT);
      Duration = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_DURATION).ToNullableTimeSpan(DEFAULT_DURATION_FORMAT);

      L1languagePresent = facets.CXMLFacetBoolValue(ConversationMetadataFacets.FACET_L1_LANGUAGE_PRESENT);
      L2languagePresent = facets.CXMLFacetBoolValue(ConversationMetadataFacets.FACET_L2_LANGUAGE_PRESENT);

      SpeakingCharactersCount = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT); //e.g. 1, 2, 3, more than 3
      L3STspeakingCharactersCount = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_L3ST_SPEAKING_CHARACTERS_COUNT); //e.g. 1, 2, 3, more than 3

      L3STlanguagesCount = int.Parse(facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_L3ST_LANGUAGES_COUNT));
      L3STlanguages = facets.CXMLFacetStringValues(ConversationMetadataFacets.FACET_L3ST_LANGUAGES);

      L3STlanguageTypesCount = int.Parse(facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES_COUNT));
      L3STlanguageTypes = facets.CXMLFacetStringValues(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES);

      L3SToccurrenceCount = int.Parse(facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_L3ST_OCCURRENCE_COUNT));

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return ConversationMetadataFacets.GetCXMLFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_START_TIME, StartTime.ToString(DEFAULT_POSITION_FORMAT)));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_DURATION, Duration.ToString(DEFAULT_DURATION_FORMAT)));

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L1_LANGUAGE_PRESENT, L1languagePresent.ToString())); //this will give True/False (not Yes/No)
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L2_LANGUAGE_PRESENT, L2languagePresent.ToString())); //this will give True/False (not Yes/No)

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_SPEAKING_CHARACTERS_COUNT, SpeakingCharactersCount));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_SPEAKING_CHARACTERS_COUNT, L3STspeakingCharactersCount));

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGES_COUNT, L3STlanguagesCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGES, L3STlanguages));

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES_COUNT, L3STlanguageTypesCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES, L3STlanguageTypes));

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_OCCURRENCE_COUNT, L3SToccurrenceCount.ToString()));

      return facets;
    }

    #endregion

  }

}