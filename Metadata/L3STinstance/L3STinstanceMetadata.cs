//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3STinstanceMetadata.cs
//Version: 20160530

using Metadata.CXML;
using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace Trafilm.Metadata
{

  public class L3STinstanceMetadata : TrafilmMetadata, IL3STinstanceMetadata
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

    public string L1language { get; set; } //Calculatable from Film

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

    //Calculatable from L3TTinstances//

    public int L3TTinstanceCount { get; set; }

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
      L3STrepresentationsOral = new string[] { };
      L3STrepresentationsVisual = new string[] { };

      L3STfunctions = new string[] { };

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      ClearCalculatedFromFilm();
      ClearCalculatedFromL3TTinstances();
    }

    public void ClearCalculatedFromFilm()
    {
      L1language = "";
    }

    public void ClearCalculatedFromL3TTinstances()
    {
      L3TTinstanceCount = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_FILM_REFERENCE_ID);
      ConversationReferenceId = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID);

      StartTime = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_START_TIME).ToNullableTimeSpan(DEFAULT_POSITION_FORMAT);
      Duration = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_DURATION).ToNullableTimeSpan(DEFAULT_DURATION_FORMAT);

      L1language = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE); //Calculatable from Film

      L3STlanguageType = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE);
      L3STlanguage = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE);

      L3STconstructedBasedOn = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_CONSTRUCTED_BASED_ON);

      L3STaudienceUnderstanding = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_AUDIENCE_UNDERSTANDING);
      L3STmessageUnderstanding = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_MESSAGE_UNDERSTANDING);
      L3STmeaningDecipherable = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_MEANING_DECIPHERABLE);

      L3STspeakerPerformance = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_SPEAKER_PERFORMANCE);

      L3STmode = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_MODE);

      L3STrepresented = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTED);
      L3STrepresentationsOral = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTATIONS_ORAL);
      L3STrepresentationsVisual = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTATIONS_VISUAL);

      L3STfunctions = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_FUNCTIONS);

      //Calculatable from L3STinstances//

      L3TTinstanceCount = int.Parse(facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3TT_INSTANCE_COUNT));

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return L3STinstanceMetadataFacets.GetCXMLFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, ConversationReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_START_TIME, StartTime.ToString(DEFAULT_POSITION_FORMAT)));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_DURATION, Duration.ToString(DEFAULT_DURATION_FORMAT)));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L1_LANGUAGE, L1language)); //Calculatable from Film

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE, L3STlanguageType));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_LANGUAGE, L3STlanguage));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_CONSTRUCTED_BASED_ON, L3STconstructedBasedOn));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_AUDIENCE_UNDERSTANDING, L3STaudienceUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_MESSAGE_UNDERSTANDING, L3STmessageUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_MEANING_DECIPHERABLE, L3STmeaningDecipherable));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_SPEAKER_PERFORMANCE, L3STspeakerPerformance));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_MODE, L3STmode));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTED, L3STrepresented));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTATIONS_ORAL, L3STrepresentationsOral));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_REPRESENTATIONS_VISUAL, L3STrepresentationsVisual));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_FUNCTIONS, L3STfunctions));

      //Calculatable from L3TTinstances//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3TT_INSTANCE_COUNT, L3TTinstanceCount.ToString()));

      return facets;
    }

    #endregion

  }

}