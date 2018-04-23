//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3STinstanceMetadata.cs
//Version: 20180423

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class L3STinstanceMetadata : TrafilmMetadata, IL3STinstanceMetadata
  {

    #region --- Properties ---

    //Linked Data: Calculatable from Conversation//

    public int? ConversationStartTime { get; set; } //in min
    public string ConversationDuration { get; set; } //in sec spans


    //Linked Data: Calculatable from Film//

    public string L1language { get; set; }

    //L3STinstance metadata//

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
    public string[] L3STconversationFeatures { get; set; }

    public string L3STsources { get; set; }

    //Linked Data: Calculatable from L3TTinstances//

    public int L3TTinstanceCount { get; set; }

    //Linked Data: References//
    public virtual string FilmReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed
    public virtual string ConversationReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

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
      L3STconversationFeatures = new string[] { };

      L3STsources = "";

      //note: don't call ClearCalculated here, has been called by base.Clear() already

      FilmReferenceId = "";
      ConversationReferenceId = "";
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      ClearCalculatedFromFilm();
      ClearCalculatedFromConversation();
      ClearCalculatedFromL3TTinstances();
    }

    public void ClearCalculatedFromFilm()
    {
      L1language = "";
    }

    public void ClearCalculatedFromConversation()
    {
      ConversationStartTime = null;
      ConversationDuration = "";
    }

    public void ClearCalculatedFromL3TTinstances()
    {
      L3TTinstanceCount = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      //Common metadata//

      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      //Linked Data: Calculatable from Conversation//

      ConversationStartTime = (int?)facets.CXMLFacetNumberValue(L3STinstanceMetadataFacets.FACET_CONVERSATION_START_TIME);
      ConversationDuration = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_CONVERSATION_DURATION);

      //Linked Data: Calculatable from Film//

      L1language = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L1_LANGUAGE);

      //L3STinstance metadata//

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
      L3STconversationFeatures = facets.CXMLFacetStringValues(L3STinstanceMetadataFacets.FACET_L3ST_CONVERSATION_FEATURES);

      L3STsources = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_L3ST_SOURCES);

      //Linked Data: Calculatable from L3TTinstances//

      L3TTinstanceCount = (int)facets.CXMLFacetNumberValue(L3STinstanceMetadataFacets.FACET_L3TT_INSTANCE_COUNT);

      //Linked Data: References//

      FilmReferenceId = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_FILM_REFERENCE_ID);
      ConversationReferenceId = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID);

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

      //Common metadata//

      base.GetCXMLFacets(facets);

      //Linked Data: Calculatable from Conversation//

      AddNonNullToList(facets, CXML.MakeNumberFacet(L3STinstanceMetadataFacets.FACET_CONVERSATION_START_TIME, ConversationStartTime));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_CONVERSATION_DURATION, ConversationDuration));

      //Linked Data: Calculatable from Film//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L1_LANGUAGE, L1language));

      //L3STinstance metadata//

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
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_CONVERSATION_FEATURES, L3STconversationFeatures));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_L3ST_SOURCES, L3STsources));

      //Linked Data: Calculatable from L3TTinstances//

      AddNonNullToList(facets, CXML.MakeNumberFacet(L3STinstanceMetadataFacets.FACET_L3TT_INSTANCE_COUNT, L3TTinstanceCount));

      //LinkedData: References//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, ConversationReferenceId));

      return facets;
    }

    #endregion

  }

}