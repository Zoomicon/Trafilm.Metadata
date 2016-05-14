//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: FilmMetadataFacets.cs
//Version: 20160504

namespace Trafilm.Metadata
{

  public static class FilmMetadataFacets
  {
    public const string FACET_TITLE_ES = "Title in Spanish";
    public const string FACET_TITLE_CA = "Title in Catalan";
    //...

    public const string FACET_DURATION = "Duration (h:m:s.f)";

    public const string FACET_DIRECTORS = "Directors";
    public const string FACET_SCRIPTWRITERS = "Scriptwriters";

    public const string FACET_PRODUCTION_COUNTRIES = "Production countries";
    public const string FACET_PRODUCTION_COMPANIES = "Production companies";

    public const string FACET_BOX_OFFICE = "Box office";
    public const string FACET_YEAR = "Year";

    public const string FACET_SOURCE_LANGUAGES = "Source languages";

    public const string FACET_YEAR_TRANSLATED = "Year translated";
    public const string FACET_DUBBED_LANGUAGES = "Dubbed languages";
    public const string FACET_SUBTITLED_LANGUAGES = "Subtitled languages";

    //Calculatable from Scenes//

    public const string FACET_SCENE_COUNT = "Scene count";
    public const string FACET_SCENES_DURATION = "Scenes duration (h:m:s.f)";
  }

}