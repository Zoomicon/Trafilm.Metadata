//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TToccurrenceMetadata.cs
//Version: 20160527

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class L3TToccurrenceMetadata : TrafilmMetadata, IL3TToccurrenceMetadata
  {

    #region --- Properties ---

    public string FilmReferenceId { get; set; }
    public string ConversationReferenceId { get; set; }
    public string L3SToccurrenceReferenceId { get; set; }

    public string L2language { get; set; }
    public string L2mode { get; set; } //dubbed, subtitled

    public bool L2sameAsL3ST { get; set; }

    public bool L3STconveyedAsL3TT { get; set; }

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

    //Calculatable from L3SToccurrence//

    public string[] L3STmodeChange { get; set; }
    public string[] L3STfunctionsChange { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";
      ConversationReferenceId = "";
      L3SToccurrenceReferenceId = "";

      L2language = "";
      L2mode = "";

      L2sameAsL3ST = false;

      L3STconveyedAsL3TT = false;

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

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      L3STmodeChange = new string[] { };
      L3STfunctionsChange = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_FILM_REFERENCE_ID);
      ConversationReferenceId = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID);
      L3SToccurrenceReferenceId = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3ST_OCCURRENCE_REFERENCE_ID);

      L2language = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L2_LANGUAGE);
      L2mode = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L2_MODE);

      L2sameAsL3ST = facets.CXMLFacetBoolValue(L3TToccurrenceMetadataFacets.FACET_L2_SAME_AS_L3ST);

      L3STconveyedAsL3TT = facets.CXMLFacetBoolValue(L3TToccurrenceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT);

      L3TTlanguageType = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3TT_LANGUAGE_TYPE);
      L3TTlanguage = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3TT_LANGUAGE);

      L3TTconstructedBasedOn = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3TT_CONSTRUCTED_BASED_ON);

      L3TTaudienceUnderstanding = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3TT_AUDIENCE_UNDERSTANDING);
      L3TTmessageUnderstanding = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3TT_MESSAGE_UNDERSTANDING);
      L3TTmeaningDecipherable = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3TT_MEANING_DECIPHERABLE);

      L3TTspeakerPerformance = facets.CXMLFacetStringValue(L3TToccurrenceMetadataFacets.FACET_L3TT_SPEAKER_PERFORMANCE);

      L3TTmode = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3TT_MODE);

      L3TTrepresented = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3TT_REPRESENTED);
      L3TTrepresentationsOral = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3TT_REPRESENTATIONS_ORAL);
      L3TTrepresentationsVisual = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3TT_REPRESENTATIONS_VISUAL);

      L3TTfunctions = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3TT_FUNCTIONS);

      //Calculatable from L3SToccurrence//

      L3STmodeChange = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3ST_MODE_CHANGE); 
      L3STfunctionsChange = facets.CXMLFacetStringValues(L3TToccurrenceMetadataFacets.FACET_L3ST_FUNCTIONS_CHANGE);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return L3TToccurrenceMetadataFacets.GetCXMLFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, ConversationReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3ST_OCCURRENCE_REFERENCE_ID, L3SToccurrenceReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L2_LANGUAGE, L2language));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L2_MODE, L2mode));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L2_SAME_AS_L3ST, L2sameAsL3ST.ToString())); //this will give True/False (not Yes/No)

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3ST_CONVEYED_AS_L3TT, L3STconveyedAsL3TT.ToString())); //this will give True/False (not Yes/No)

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_LANGUAGE_TYPE, L3TTlanguageType));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_LANGUAGE, L3TTlanguage));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_CONSTRUCTED_BASED_ON, L3TTconstructedBasedOn));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_AUDIENCE_UNDERSTANDING, L3TTaudienceUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_MESSAGE_UNDERSTANDING, L3TTmessageUnderstanding));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_MEANING_DECIPHERABLE, L3TTmeaningDecipherable));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_SPEAKER_PERFORMANCE, L3TTspeakerPerformance));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_MODE, L3TTmode));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_REPRESENTED, L3TTrepresented));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_REPRESENTATIONS_ORAL, L3TTrepresentationsOral));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_REPRESENTATIONS_VISUAL, L3TTrepresentationsVisual));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3TT_FUNCTIONS, L3TTfunctions));

      //Calculatable from L3SToccurrence//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3ST_MODE_CHANGE, L3STmodeChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TToccurrenceMetadataFacets.FACET_L3ST_FUNCTIONS_CHANGE, L3STfunctionsChange));

      return facets;
    }

    #endregion

  }

}