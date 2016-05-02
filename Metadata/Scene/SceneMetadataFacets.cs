//Project: Trafilm (http://trafilm.net)
//Filename: SceneMetadataFacets.cs
//Version: 20160502

namespace Trafilm.Metadata
{

  public static class SceneMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";

    public const string FACET_START_TIME = "Start time (hh:mm:ss.fs)";
    public const string FACET_DURATION = "Duration (mm:ss.fs)";

    public const string FACET_L1_SOURCE_LANGUAGE_PRESENT = "L1-Source language present";
    public const string FACET_L2_TRANSLATED_LANGUAGE_PRESENT = "L2-Translated language present";

    //Calculatable//

    public const string FACET_L3_OTHER_LANGUAGES_COUNT = "L3-Other language count";
    public const string FACET_L3_OTHER_LANGUAGES = "L3-Other languages";

    public const string FACET_UTTERANCE_COUNT = "Utterance count";
  }

}