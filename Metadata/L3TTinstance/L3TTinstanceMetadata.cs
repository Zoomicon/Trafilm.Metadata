﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TTinstanceMetadata.cs
//Version: 20160908

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class L3TTinstanceMetadata : TrafilmMetadata, IL3TTinstanceMetadata
  {

    #region --- Properties ---

    public virtual string FilmReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed
    public virtual string ConversationReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed
    public virtual string L3STinstanceReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed

    public string FilmTitleTT { get; set; }
    public int? YearTTreleased { get; set; }
    //public string BoxOfficeTT { get; set; }

    public string L2language { get; set; }
    public string L2mode { get; set; } //dubbed, subtitled

    public int? StartTime { get; set; } //in minutes //Calculatable from L3STinstance
    public int? Duration { get; set; } //in minutes //Calculatable from L3STinstance

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
    public string[] L3TTtypesFeatures { get; set; }

    public string L3TTsources { get; set; }

    //Calculatable from L3STinstance//

    public string[] L3STlanguageTypeChange { get; set; }
    public string[] L3STmodeChange { get; set; }
    public string[] L3STfunctionsChange { get; set; }
    public string[] L3STtypesFeaturesChange { get; set; }
    public string[] L3STsourcesChange { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";
      ConversationReferenceId = "";
      L3STinstanceReferenceId = "";

      FilmTitleTT = "";
      YearTTreleased = null;
      //BoxOfficeTT = "";

      L2language = "";
      L2mode = "";

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
      L3TTtypesFeatures = new string[] { };

      L3TTsources = "";

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      StartTime = null;
      Duration = null;

      L3STlanguageTypeChange = new string[] { };
      L3STmodeChange = new string[] { };
      L3STfunctionsChange = new string[] { };
      L3STtypesFeaturesChange = new string[] { };
      L3STsourcesChange = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      FilmReferenceId = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_FILM_REFERENCE_ID);
      ConversationReferenceId = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID);
      L3STinstanceReferenceId = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3ST_INSTANCE_REFERENCE_ID);

      FilmTitleTT = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_FILM_TITLE_TT);
      YearTTreleased = (int?)facets.CXMLFacetNumberValue(L3TTinstanceMetadataFacets.FACET_YEAR_TT_RELEASED);
      //BoxOfficeTT = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_BOX_OFFICE_TT);

      L2language = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L2_LANGUAGE);
      L2mode = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L2_MODE);

      StartTime = (int?)facets.CXMLFacetNumberValue(L3STinstanceMetadataFacets.FACET_START_TIME); //Calculatable from L3STinstance
      Duration = (int?)facets.CXMLFacetNumberValue(L3STinstanceMetadataFacets.FACET_DURATION); //Calculatable from L3STinstance

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
      L3TTtypesFeatures = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3TT_TYPES_FEATURES);

      L3TTsources = facets.CXMLFacetStringValue(L3TTinstanceMetadataFacets.FACET_L3TT_SOURCES);

      //Calculatable from L3STinstance//

      L3STlanguageTypeChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE_CHANGE);
      L3STmodeChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3ST_MODE_CHANGE); 
      L3STfunctionsChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3ST_FUNCTIONS_CHANGE);
      L3STtypesFeaturesChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3ST_TYPES_FEATURES_CHANGE);
      L3STsourcesChange = facets.CXMLFacetStringValues(L3TTinstanceMetadataFacets.FACET_L3ST_SOURCES_CHANGE);

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

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_CONVERSATION_REFERENCE_ID, ConversationReferenceId));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_INSTANCE_REFERENCE_ID, L3STinstanceReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_FILM_TITLE_TT, FilmTitleTT));
      AddNonNullToList(facets, CXML.MakeNumberFacet(L3TTinstanceMetadataFacets.FACET_YEAR_TT_RELEASED, YearTTreleased));
      //AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_BOX_OFFICE_TT, BoxOfficeTT));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L2_LANGUAGE, L2language));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L2_MODE, L2mode));

      AddNonNullToList(facets, CXML.MakeNumberFacet(L3STinstanceMetadataFacets.FACET_START_TIME, StartTime));
      AddNonNullToList(facets, CXML.MakeNumberFacet(L3STinstanceMetadataFacets.FACET_DURATION, Duration));

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
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_TYPES_FEATURES, L3TTtypesFeatures));

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3TT_SOURCES, L3TTsources));

      //Calculatable from L3STinstance//

      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_LANGUAGE_TYPE_CHANGE, L3STlanguageTypeChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_MODE_CHANGE, L3STmodeChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_FUNCTIONS_CHANGE, L3STfunctionsChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_TYPES_FEATURES_CHANGE, L3STtypesFeaturesChange));
      AddNonNullToList(facets, CXML.MakeStringFacet(L3TTinstanceMetadataFacets.FACET_L3ST_SOURCES_CHANGE, L3STsourcesChange));

      return facets;
    }

    #endregion

  }

}