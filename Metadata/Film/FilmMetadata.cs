//Project: Trafilm (http://trafilm.net)
//Filename: FilmMetadata.cs
//Version: 20160430

using Metadata.CXML;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class FilmMetadata : TrafilmMetadata, IFilmMetadata
  {

    #region --- Properties ---

    public string Title_source { get; set; }
    public string Title_es { get; set; }
    public string Title_ca { get; set; }
    //...

    public string Director { get; set; }
    public string Scriptwriter { get; set; }

    public string ProductionCountry { get; set; }
    public string ProductionCompany { get; set; }

    public string Duration { get; set; }

    public string[] SourceLanguage { get; set; }
    public string[] DubbedLanguage { get; set; }
    public string[] SubtitledLanguage { get; set; }

    public string SceneCount { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      Title_source = "";
      Title_es = "";
      Title_ca = "";
      //...

      Director = "";
      Scriptwriter = "";

      ProductionCountry = "";
      ProductionCompany = "";

      Duration = "0:0:0";

      SourceLanguage = new string[] { };
      DubbedLanguage = new string[] { };
      SubtitledLanguage = new string[] { };

      SceneCount = "0";
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      Title_source = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_TITLE_SOURCE);
      Title_es = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_TITLE_ES);
      Title_ca = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_TITLE_CA);
      //...

      Director = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_DIRECTOR);
      Scriptwriter = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_SCRIPTWRITER);

      ProductionCountry = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_PRODUCTION_COUNTRY);
      ProductionCompany = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_PRODUCTION_COMPANY);

      Duration = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_DURATION);

      SourceLanguage = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_SOURCE_LANGUAGE);
      DubbedLanguage = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_DUBBED_LANGUAGE);
      SubtitledLanguage = facets.CXMLFacetStringValues(FilmMetadataFacets.FACET_SUBTITLED_LANGUAGE);

      SceneCount = facets.CXMLFacetStringValue(FilmMetadataFacets.FACET_SCENE_COUNT);

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

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_TITLE_SOURCE, Title_source));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_TITLE_ES, Title_es));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_TITLE_CA, Title_ca));
      //...

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DIRECTOR, Director));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SCRIPTWRITER, Scriptwriter));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_PRODUCTION_COUNTRY, ProductionCountry));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_PRODUCTION_COMPANY, ProductionCompany));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DURATION, Duration));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SOURCE_LANGUAGE, SourceLanguage));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_DUBBED_LANGUAGE, DubbedLanguage));
      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SUBTITLED_LANGUAGE, SubtitledLanguage));

      AddNonNullToList(facets, CXML.MakeStringFacet(FilmMetadataFacets.FACET_SCENE_COUNT, SceneCount));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeFilmFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null,isFilterVisible: false, isMetadataVisible: false, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_SOURCE, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_ES, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TITLE_CA, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: true));
      //...

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DIRECTOR, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SCRIPTWRITER, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COUNTRY, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COMPANY, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SOURCE_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DUBBED_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SUBTITLED_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SCENE_COUNT, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}