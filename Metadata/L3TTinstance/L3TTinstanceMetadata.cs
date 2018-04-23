//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TTinstanceMetadata.cs
//Version: 20180423

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class L3TTinstanceMetadata : TrafilmMetadata, IL3TTinstanceMetadata
  {

    #region --- Properties ---

    //L3TTinstance metadata (1/2)//

    public string FilmTitleTT { get; set; }

    public string L2language { get; set; }
    public string L2mode { get; set; } //dubbed, subtitled

    public string[] DistributionCountriesTT { get; set; }
    public int? YearTTreleased { get; set; }
    public string BlockbusterTT { get; set; }


    //Linked Data: Calculatable from Conversation (via L3STinstance)//

    public int? ConversationStartTime { get; set; } //in min
    public string ConversationDuration { get; set; } //in sec spans

    //L3TTinstance metadata (2/2)//

    public string L2sameAsL3ST { get; set; }

    public string L3STconveyedAsL3TT { get; set; }

    public string L3TTlanguageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    public string L3TTlanguage { get; set; }

    public string[] L3TTconstructedBasedOn { get; set; }

    public string L3TTaudienceUnderstanding { get; set; }
    public string L3TTmessageUnderstanding { get; set; }
    public string L3TTmeaningDecipherable { get; set; }

    public string L3TTspeakerPerformance { get; set; }

    public string[] L3TTmode { get; set; }

    public string[] L3TTrepresented { get; set; }
    public string[] L3TTrepresentationsOral { get; set; }
    public string[] L3TTrepresentationsVisual { get; set; }

    public string[] L3TTfunctions { get; set; }
    public string[] L3TTconversationFeatures { get; set; }

    public string L3TTsources { get; set; }

    //Calculatable from L3STinstance//

    public string[] L3languageTypeChange { get; set; }
    public string[] L3modeChange { get; set; }
    public string[] L3functionsChange { get; set; }
    public string[] L3conversationFeaturesChange { get; set; }
    public string[] L3sourcesChange { get; set; }

    //Linked Data: References//

    public virtual string FilmReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed
    public virtual string ConversationReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed
    public virtual string L3STinstanceReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed
    
    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmTitleTT = "";

      L2language = "";
      L2mode = "";

      DistributionCountriesTT = new string[] { };
      YearTTreleased = null;
      BlockbusterTT = "";

      L2sameAsL3ST = "";

      L3STconveyedAsL3TT = "";

      L3TTlanguageType = "";
      L3TTlanguage = "";

      L3TTconstructedBasedOn = new string[] { };

      L3TTaudienceUnderstanding = "";
      L3TTmessageUnderstanding = "";
      L3TTmeaningDecipherable = "";

      L3TTspeakerPerformance = "";

      L3TTmode = new string[] { };

      L3TTrepresented = new string[] { };
      L3TTrepresentationsOral= new string[] { };
      L3TTrepresentationsVisual = new string[] { };

      L3TTfunctions = new string[] { };
      L3TTconversationFeatures = new string[] { };

      L3TTsources = "";

      //note: don't call ClearCalculated here, has been called by base.Clear() already

      FilmReferenceId = "";
      ConversationReferenceId = "";
      L3STinstanceReferenceId = "";
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      Description = ""; //Calculated from L3STinstance

      ConversationStartTime = null;
      ConversationDuration = "";

      L3languageTypeChange = new string[] { };
      L3modeChange = new string[] { };
      L3functionsChange = new string[] { };
      L3conversationFeaturesChange = new string[] { };
      L3sourcesChange = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      //Common metadata

      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      //L3TTinstance metadata (1/2)//

      FilmTitleTT = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_FILM_TITLE_TT);

      L2language = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L2_LANGUAGE);
      L2mode = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L2_MODE);

      DistributionCountriesTT = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_DISTRIBUTION_COUNTRIES_TT);
      YearTTreleased = (int?)facets.CXMLFacetNumberValue(L3TTinstanceMetadataFacets.FACET_YEAR_TT_RELEASED);
      BlockbusterTT = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_BLOCKBUSTER_TT);

      //Linked Data: Calculatable from Conversation (via L3STinstance)//

      ConversationStartTime = (int?)facets.CXMLFacetNumberValue(L3STinstanceMetadataFacets.FACET_CONVERSATION_START_TIME);
      ConversationDuration = facets.CXMLFacetStringValue(L3STinstanceMetadataFacets.FACET_CONVERSATION_DURATION);

      //L3TTinstance metadata (2/2)//

      L2sameAsL3ST = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L2_SAME_AS_L3ST);

      L3STconveyedAsL3TT = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT);

      L3TTlanguageType = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_LANGUAGE_TYPE);
      L3TTlanguage = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_LANGUAGE);

      L3TTconstructedBasedOn = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_CONSTRUCTED_BASED_ON);

      L3TTaudienceUnderstanding = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_AUDIENCE_UNDERSTANDING);
      L3TTmessageUnderstanding = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_MESSAGE_UNDERSTANDING);
      L3TTmeaningDecipherable = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_MEANING_DECIPHERABLE);

      L3TTspeakerPerformance = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_SPEAKER_PERFORMANCE);

      L3TTmode = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_MODE);

      L3TTrepresented = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTED);
      L3TTrepresentationsOral = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTATIONS_ORAL);
      L3TTrepresentationsVisual = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTATIONS_VISUAL);

      L3TTfunctions = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_FUNCTIONS);
      L3TTconversationFeatures = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_CONVERSATION_FEATURES);

      L3TTsources = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_SOURCES);

      //Linked Data: Calculatable from L3STinstance//

      L3languageTypeChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3_LANGUAGE_TYPE_CHANGE);
      L3modeChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3_MODE_CHANGE); 
      L3functionsChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3_FUNCTIONS_CHANGE);
      L3conversationFeaturesChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3_CONVERSATION_FEATURES_CHANGE);
      L3sourcesChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3_SOURCES_CHANGE);

      //Linked Data: References//

      FilmReferenceId = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_FILM_REFERENCE_ID);
      ConversationReferenceId = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID);
      L3STinstanceReferenceId = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3ST_INSTANCE_REFERENCE_ID);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return L3TTinstanceMetadataFacets.GetCXMLFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      //Common metadata//

      base.GetCXMLFacets(facets);

      //L3TTinstance metadata (1/2)

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_FILM_TITLE_TT, FilmTitleTT));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L2_LANGUAGE, L2language));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L2_MODE, L2mode));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_DISTRIBUTION_COUNTRIES_TT, DistributionCountriesTT));
      AddNonNullToList(facets, CXML.MakeNumberFacet(L3TTinstanceMetadataFacets.FACET_YEAR_TT_RELEASED, YearTTreleased));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_BLOCKBUSTER_TT, BlockbusterTT));

      //Linked Data: Calculatable from Conversation (via L3STinstance)

      AddNonNullToList(facets, CXML.MakeNumberFacet(L3STinstanceMetadataFacets.FACET_CONVERSATION_START_TIME, ConversationStartTime));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3STinstanceMetadataFacets.FACET_CONVERSATION_DURATION, ConversationDuration));

      //L3TTinstance metadata (2/2)//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L2_SAME_AS_L3ST, L2sameAsL3ST));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT, L3STconveyedAsL3TT));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_LANGUAGE_TYPE, L3TTlanguageType));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_LANGUAGE, L3TTlanguage));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_CONSTRUCTED_BASED_ON, L3TTconstructedBasedOn));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_AUDIENCE_UNDERSTANDING, L3TTaudienceUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_MESSAGE_UNDERSTANDING, L3TTmessageUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_MEANING_DECIPHERABLE, L3TTmeaningDecipherable));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_SPEAKER_PERFORMANCE, L3TTspeakerPerformance));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_MODE, L3TTmode));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTED, L3TTrepresented));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTATIONS_ORAL, L3TTrepresentationsOral));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_REPRESENTATIONS_VISUAL, L3TTrepresentationsVisual));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_FUNCTIONS, L3TTfunctions));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_CONVERSATION_FEATURES, L3TTconversationFeatures));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_SOURCES, L3TTsources));

      //Linked Data: Calculatable from L3STinstance//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3_LANGUAGE_TYPE_CHANGE, L3languageTypeChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3_MODE_CHANGE, L3modeChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3_FUNCTIONS_CHANGE, L3functionsChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3_CONVERSATION_FEATURES_CHANGE, L3conversationFeaturesChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3_SOURCES_CHANGE, L3sourcesChange));

      //Linked Data: References//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, ConversationReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_INSTANCE_REFERENCE_ID, L3STinstanceReferenceId));

      return facets;
    }

    #endregion

  }

}