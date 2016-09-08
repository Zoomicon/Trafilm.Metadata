﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: FilmMetadata.cs
//Version: 20160908

using Metadata.CXML;
using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class FilmMetadata : TrafilmMetadata, IFilmMetadata
  {

    #region --- Properties ---

    public string Title_es { get; set; }
    public string Title_ca { get; set; }
    //...

    public int? Duration { get; set; }

    public string[] Directors { get; set; }
    public string[] Scriptwriters { get; set; }

    public string[] ProductionCountries { get; set; }
    public string[] ProductionCompanies { get; set; }

    public string BoxOffice { get; set; }
    public int? YearSTreleased { get; set; }

    public string L1language { get; set; }

    public int? YearTTreleased_Spain { get; set; }

    //Calculatable from Conversations.L3STinstances.L3TTinstances//

    public string[] L2dubbedLanguages { get; set; }
    public string[] L2subtitledLanguages { get; set; }
    
    //Calculatable from Conversations//

    public int ConversationCount { get; set; }
    public int? ConversationsDuration { get; set; } //in minutes

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      Duration = null;

      Directors = new string[] { };
      Scriptwriters = new string[] { };

      ProductionCountries = new string[] { };
      ProductionCompanies = new string[] { };

      BoxOffice = "";
      YearSTreleased = null;

      L1language = "";

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      L2dubbedLanguages = new string[] { };
      L2subtitledLanguages = new string[] { };

      ConversationCount = 0;
      ConversationsDuration = 0;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      Duration = (int?)facets.CXMLFacetNumberValue(FilmMetadataFacets.FACET_DURATION);

      Directors = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_DIRECTORS);
      Scriptwriters = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_SCRIPTWRITERS);

      ProductionCountries = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES);
      ProductionCompanies = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES);

      BoxOffice = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_BOX_OFFICE);
      YearSTreleased = (int?)facets.CXMLFacetNumberValue(FilmMetadataFacets.FACET_YEAR_ST_RELEASED);

      L1language = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_L1_LANGUAGE);

      //Calculatable from Conversations.L3STinstances.L3TTinstances//

      L2dubbedLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_L2_DUBBED_LANGUAGES);
      L2subtitledLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_L2_SUBTITLED_LANGUAGES);
      
      //Calculatable from Conversations//

      ConversationCount = (int)facets.CXMLFacetNumberValue(FilmMetadataFacets.FACET_CONVERSATION_COUNT);
      ConversationsDuration = (int?)facets.CXMLFacetNumberValue(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return FilmMetadataFacets.GetCXMLFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
       if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);

      AddNonNullToList(facets, CXML.MakeNumberFacet(FilmMetadataFacets.FACET_DURATION, Duration));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DIRECTORS, Directors));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SCRIPTWRITERS, Scriptwriters));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES, ProductionCountries));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES, ProductionCompanies));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_BOX_OFFICE, BoxOffice));
      AddNonNullToList(facets, CXML.MakeNumberFacet(FilmMetadataFacets.FACET_YEAR_ST_RELEASED, YearSTreleased));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_L1_LANGUAGE, L1language));

      //Calculatable from Conversations.L3STinstances.L3TTinstances//

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_L2_DUBBED_LANGUAGES, L2dubbedLanguages));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_L2_SUBTITLED_LANGUAGES, L2subtitledLanguages));

      //Calculatable from Conversations//

      AddNonNullToList(facets, CXML.MakeNumberFacet(FilmMetadataFacets.FACET_CONVERSATION_COUNT, ConversationCount));
      AddNonNullToList(facets, CXML.MakeNumberFacet(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION, ConversationsDuration));

      return facets;
    }

    #endregion

  }

}