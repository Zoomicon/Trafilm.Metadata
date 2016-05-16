//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: FilmMetadata.cs
//Version: 20160516

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
    public int? Year { get; set; }

    public string[] SourceLanguages { get; set; }

    public int? YearTranslated { get; set; }
    public string[] DubbedLanguages { get; set; }
    public string[] SubtitledLanguages { get; set; }

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
      Year = null;

      SourceLanguages = new string[] { };

      YearTranslated = null;
      DubbedLanguages = new string[] { };
      SubtitledLanguages = new string[] { };

      //note: don't call ClearCalculated here, has been called by base.Clear() already
    }

    public override void ClearCalculated()
    {
      base.ClearCalculated();

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
      Year = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_YEAR).ToNullableInt();

      SourceLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_SOURCE_LANGUAGES);

      YearTranslated = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_YEAR_TRANSLATED).ToNullableInt();
      DubbedLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_DUBBED_LANGUAGES);
      SubtitledLanguages = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_SUBTITLED_LANGUAGES);

      ConversationCount = int.Parse(facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_CONVERSATION_COUNT));
      ConversationsDuration = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION).ToNullableTimeSpan(ConversationMetadata.DEFAULT_DURATION_FORMAT);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeFilmFacetCategories();
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
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_YEAR, Year.ToString())); //for nullable types, ToString() method returns "" if HasValue is false

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SOURCE_LANGUAGES, SourceLanguages));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_YEAR_TRANSLATED, YearTranslated.ToString())); //for nullable types, ToString() method returns "" if HasValue is false
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DUBBED_LANGUAGES, DubbedLanguages));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SUBTITLED_LANGUAGES, SubtitledLanguages));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_CONVERSATION_COUNT, ConversationCount.ToString()));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION, ConversationsDuration.ToString(DEFAULT_DURATION_FORMAT)));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeFilmFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null,isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));

      //

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_ES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_CA, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      //...

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DIRECTORS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SCRIPTWRITERS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_BOX_OFFICE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_YEAR, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SOURCE_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_YEAR_TRANSLATED, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DUBBED_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SUBTITLED_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_CONVERSATION_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_CONVERSATIONS_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}