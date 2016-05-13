//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: SceneMetadataFacets.cs
//Version: 20160512

namespace Trafilm.Metadata
{

  public static class SceneMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";

    public const string FACET_START_TIME = "Start time (hh:mm:ss.fs)";
    public const string FACET_DURATION = "Duration (mm:ss.fs)";

    public const string FACET_L1_LANGUAGE_PRESENT = "L1/Source language present";
    public const string FACET_L2_LANGUAGE_PRESENT = "L2/Translated language present";

    public const string FACET_SPEAKING_CHARACTERS_COUNT = "Speaking characters count";
    public const string FACET_L3_SPEAKING_CHARACTERS_COUNT = "L3-Speaking characters count";

    //Calculatable from Utterances//

    public const string FACET_L3_LANGUAGES_COUNT = "L3 languages count";
    public const string FACET_L3_LANGUAGES = "L3/Other languages";

    public const string FACET_L3_LANGUAGE_TYPES_COUNT = "L3 language types count";
    public const string FACET_L3_LANGUAGE_TYPES = "L3 language types";

    public const string FACET_UTTERANCE_COUNT = "Utterance count";
  }

}