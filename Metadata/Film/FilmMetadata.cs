//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: FilmMetadata.cs
//Version: 20160527

using Metadata.CXML;
using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class FilmMetadata : TrafilmMetadata, IFilmMetadata
  {

    #region --- Constants ---

    public const string DEFAULT_DURATION_FORMAT = "g";

    #endregion

    #region --- Properties ---

    public string Title_es { get; set; }
    public string Title_ca { get; set; }
    //...

    public TimeSpan? Duration { get; set; }

    public string[] Directors { get; set; }
    public string[] Scriptwriters { get; set; }

    public string[] ProductionCountries { get; set; }
    public string[] ProductionCompanies { get; set; }

    public string BoxOffice { get; set; }
    public int? YearSTreleased { get; set; }

    public string L1language { get; set; }

    public int? YearTTreleased_Spain { get; set; }

    //Calculatable from Conversations.L3SToccurrences.L3TToccurrences//

    public string[] L2dubbedLanguages { get; set; }
    public string[] L2subtitledLanguages { get; set; }
    
    //Calculatable from Conversations//

    public int ConversationCount { get; set; }
    public TimeSpan? ConversationsDuration { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      Title_es = "";
      Title_ca = "";
      //...

      Duration = null;

      Directors = new string[] { };
      Scriptwriters = new string[] { };

      ProductionCountries = new string[] { };
      ProductionCompanies = new string[] { };

      BoxOffice = "";
      YearSTreleased = null;

      L1language = "";

      YearTTreleased_Spain = null;

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

      L2dubbedLanguages = new string[] { };
      L2subtitledLanguages = new string[] { };

      ConversationCount = 0;
      ConversationsDuration = TimeSpan.Zero;
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      Title_es = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_TITLE_ES);
      Title_ca = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_TITLE_CA);
      //...

      Duration = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_DURATION).ToNullableTimeSpan(DEFAULT_DURATION_FORMAT);

      Directors = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_DIRECTORS);
      Scriptwriters = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_SCRIPTWRITERS);

      ProductionCountries = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES);
      ProductionCompanies = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES);

      BoxOffice = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_BOX_OFFICE);
      YearSTreleased = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_YEAR_ST_RELEASED).ToNullableInt();

      L1language = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_L1_LANGUAGE);

      YearTTreleased_Spain = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_YEAR_TT_RELEASED_SPAIN).ToNullableInt();

      //Calculatable from Conversations.L3SToccurrences.L3TToccurrences//

      L2dubbedLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_L2_DUBBED_LANGUAGES);
      L2subtitledLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_L2_SUBTITLED_LANGUAGES);
      
      //Calculatable from Conversations//

      ConversationCount = int.Parse(facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_CONVERSATION_COUNT));
      ConversationsDuration = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION).ToNullableTimeSpan(ConversationMetadata.DEFAULT_DURATION_FORMAT);

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

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_TITLE_ES, Title_es));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_TITLE_CA, Title_ca));
      //...

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DURATION, Duration.ToString(DEFAULT_DURATION_FORMAT))); //for nullable types, ToString() method returns "" if HasValue is false

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DIRECTORS, Directors));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SCRIPTWRITERS, Scriptwriters));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES, ProductionCountries));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES, ProductionCompanies));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_BOX_OFFICE, BoxOffice));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_YEAR_ST_RELEASED, YearSTreleased.ToString())); //for nullable types, ToString() method returns "" if HasValue is false

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_L1_LANGUAGE, L1language));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_YEAR_TT_RELEASED_SPAIN, YearTTreleased_Spain.ToString())); //for nullable types, ToString() method returns "" if HasValue is false

      //Calculatable from Conversations.L3SToccurrences.L3TToccurrences//

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_L2_DUBBED_LANGUAGES, L2dubbedLanguages));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_L2_SUBTITLED_LANGUAGES, L2subtitledLanguages));

      //Calculatable from Conversations//

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_CONVERSATION_COUNT, ConversationCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION, ConversationsDuration.ToString(DEFAULT_DURATION_FORMAT)));

      return facets;
    }

    #endregion

  }

}