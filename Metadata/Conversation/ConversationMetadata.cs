﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ConversationMetadata.cs
//Version: 20180509

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class ConversationMetadata : TrafilmMetadata, IConversationMetadata
  {

    #region --- Properties ---

    //Conversation metadata//

    public string FilmOrSeasonTitle { get; set; } //Calculatable from Film
    public string SeasonEpisodeName { get; set; }

    public int? StartTime { get; set; } //in min
    public string Duration { get; set; } //in sec spans

    //public string LanguageSources { get; set; } //(NOT USED)

    //Linked Data: Calculatable from L3STinstances//

    public int L3STlanguagesCount { get; set; }
    public string[] L3STlanguages { get; set; }

    public int L3STlanguageTypesCount { get; set; }
    public string[] L3STlanguageTypes { get; set; }

    public int L3STinstanceCount { get; set; }

    //Linked Data: References//
    public virtual string FilmReferenceId { get; set; } //descendents can override this property to propagate change of ReferenceId where needed

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      SeasonEpisodeName = "";

      StartTime = null;
      Duration = "";

      //LanguageSources = ""; //(NOT USED)

      //note: don't call ClearCalculated here, has been called by base.Clear() already

      FilmReferenceId = "";
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      FilmOrSeasonTitle = "";

      L3STlanguagesCount = 0;
      L3STlanguages = new string[] { };

      L3STlanguageTypesCount = 0;
      L3STlanguageTypes = new string[] { };

      L3STinstanceCount = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      //Common metadata//

      base.Load(item);

      //Conversation metadata//

      IEnumerable<XElement> facets = FindFacets(item);

      FilmOrSeasonTitle = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_FILM_OR_SEASON_TITLE); //Calculatable from Film
      SeasonEpisodeName = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_SEASON_EPISODE_NAME);

      StartTime = (int?)facets.CXMLFacetNumberValue(ConversationMetadataFacets.FACET_START_TIME);
      Duration = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_DURATION);

      //LanguageSources = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_LANGUAGE_SOURCES); //(NOT USED)

      //Linked Data: Calculatable from L3STinstances//

      L3STlanguagesCount = (int)facets.CXMLFacetNumberValue(ConversationMetadataFacets.FACET_L3ST_LANGUAGES_COUNT);
      L3STlanguages = facets.CXMLFacetStringValues(ConversationMetadataFacets.FACET_L3ST_LANGUAGES);

      L3STlanguageTypesCount = (int)facets.CXMLFacetNumberValue(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES_COUNT);
      L3STlanguageTypes = facets.CXMLFacetStringValues(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES);

      L3STinstanceCount = (int)facets.CXMLFacetNumberValue(ConversationMetadataFacets.FACET_L3ST_INSTANCE_COUNT);

      //Linked Data: References//

      FilmReferenceId = facets.CXMLFacetStringValue(ConversationMetadataFacets.FACET_FILM_REFERENCE_ID);

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

      //Common metadata//

      base.GetCXMLFacets(facets);

      //Conversation metadata//

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_FILM_OR_SEASON_TITLE, FilmOrSeasonTitle));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_SEASON_EPISODE_NAME, SeasonEpisodeName));

      AddNonNullToList(facets, CXML.MakeNumberFacet(ConversationMetadataFacets.FACET_START_TIME, StartTime));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_DURATION, Duration));

      //AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_LANGUAGE_SOURCES, LanguageSources)); //(NOT USED)

      //Linked Data: Calculatable from L3STinstances//

      AddNonNullToList(facets, CXML.MakeNumberFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGES_COUNT, L3STlanguagesCount));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGES, L3STlanguages));

      AddNonNullToList(facets, CXML.MakeNumberFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES_COUNT, L3STlanguageTypesCount));
      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_L3ST_LANGUAGE_TYPES, L3STlanguageTypes));

      AddNonNullToList(facets, CXML.MakeNumberFacet(ConversationMetadataFacets.FACET_L3ST_INSTANCE_COUNT, L3STinstanceCount));

      //Linked Data: References//

      AddNonNullToList(facets, CXML.MakeStringFacet(ConversationMetadataFacets.FACET_FILM_REFERENCE_ID, FilmReferenceId));

      return facets;
    }

    #endregion

  }

}