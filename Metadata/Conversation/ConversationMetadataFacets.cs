//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ConversationMetadataFacets.cs
//Version: 20160524

namespace Trafilm.Metadata
{

  public static class ConversationMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";

    public const string FACET_START_TIME = "Start time (h:m:s.f)";
    public const string FACET_DURATION = "Duration (h:m:s.f)";

    public const string FACET_L1_LANGUAGE_PRESENT = "L1/Source language present";
    public const string FACET_L2_LANGUAGE_PRESENT = "L2/Translated language present";

    public const string FACET_SPEAKING_CHARACTERS_COUNT = "Speaking characters count";
    public const string FACET_L3_SPEAKING_CHARACTERS_COUNT = "L3-Speaking characters count";

    //Calculatable from L3occurrences//

    public const string FACET_L3_LANGUAGES_COUNT = "L3 languages count";
    public const string FACET_L3_LANGUAGES = "L3/Other languages";

    public const string FACET_L3_LANGUAGE_TYPES_COUNT = "L3 language types count";
    public const string FACET_L3_LANGUAGE_TYPES = "L3 language types";

    public const string FACET_L3_OCCURRENCE_COUNT = "L3-occurrence count";
  }

}