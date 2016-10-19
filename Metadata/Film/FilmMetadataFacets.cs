//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: FilmMetadataFacets.cs
//Version: 20161019

using Metadata.CXML;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public static class FilmMetadataFacets
  {

    #region --- Constants ---

    public const string FACET_FILM_OR_SEASON_TITLE = "Film/Season title"; //Alias for CXMLMetadata Title attribute

    public const string FACET_TYPE = "Type"; //Feature film, Short film, TV film, TV series

    public const string FACET_DURATION = "Duration (min)";

    public const string FACET_SERIES = "Series";

    public const string FACET_DIRECTORS = "Director(s)";
    public const string FACET_SCRIPTWRITERS = "Scriptwriter(s)";

    public const string FACET_PRODUCTION_COUNTRIES = "Production countries";
    public const string FACET_PRODUCTION_COMPANIES = "Production companies";

    public const string FACET_BLOCKBUSTER = "Blockbuster";
    public const string FACET_YEAR_ST_RELEASED = "Year ST released";

    public const string FACET_L1_LANGUAGE = "Main language (L1)";

    //Calculatable from Conversations.L3STinstances.L3TTinstances//

    public const string FACET_L2_DUBBED_LANGUAGES = "L2-Dubbed languages";
    public const string FACET_L2_SUBTITLED_LANGUAGES = "L2-Subtitled languages";
    
    //Calculatable from Conversations//

    public const string FACET_CONVERSATION_COUNT = "Conversations: count";

    #endregion

    #region --- Methods ---

    public static IEnumerable<XElement> GetCXMLFacetCategories(IList<XElement> result = null) //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      if (result == null)
        result = new List<XElement>();

      TrafilmMetadataFacets.GetCXMLFacetCategories_Header(result);

      //

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_FILM_OR_SEASON_TITLE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true)); //Calculatable from Film

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_TYPE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DURATION, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SERIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_DIRECTORS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_SCRIPTWRITERS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COUNTRIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_PRODUCTION_COMPANIES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_BLOCKBUSTER, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_YEAR_ST_RELEASED, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_L1_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from Conversations.L3STinstances.L3TTinstances//

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_L2_DUBBED_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_L2_SUBTITLED_LANGUAGES, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      //Calculatable from Conversations//

      result.Add(CXML.MakeFacetCategory(FilmMetadataFacets.FACET_CONVERSATION_COUNT, CXML.VALUE_NUMBER, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //

      TrafilmMetadataFacets.GetCXMLFacetCategories_Footer(result);

      return result;
    }

    #endregion
  }

}