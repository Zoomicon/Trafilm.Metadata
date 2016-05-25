//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ConversationMetadataFacets.cs
//Version: 20160525

namespace Trafilm.Metadata
{

  public static class ConversationMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";

    public const string FACET_START_TIME = "Start time (h:m:s.f)";
    public const string FACET_DURATION = "Duration (h:m:s.f)";

    public const string FACET_L1_LANGUAGE_PRESENT = "L1 language present";
    public const string FACET_L2_LANGUAGE_PRESENT = "L2 language present";

    public const string FACET_SPEAKING_CHARACTERS_COUNT = "Speaking characters: count";
    public const string FACET_L3ST_SPEAKING_CHARACTERS_COUNT = "L3ST-speaking characters: count";

    //Calculatable from L3SToccurrences//

    public const string FACET_L3ST_LANGUAGES_COUNT = "L3ST languages: count";
    public const string FACET_L3ST_LANGUAGES = "L3ST languages";

    public const string FACET_L3ST_LANGUAGE_TYPES_COUNT = "L3ST language types: count";
    public const string FACET_L3ST_LANGUAGE_TYPES = "L3ST language types";

    public const string FACET_L3ST_OCCURRENCE_COUNT = "L3ST-occurrences: count";
  }

}