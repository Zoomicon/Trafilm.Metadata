//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TToccurrenceMetadataFacets.cs
//Version: 20160525

namespace Trafilm.Metadata
{

  public static class L3TToccurrenceMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";
    public const string FACET_CONVERSATION_REFERENCE_ID = "Conversation Reference Id";
    public const string FACET_L3ST_OCCURRENCE_REFERENCE_ID = "L3ST-occurrence Reference Id";

    public const string FACET_L2_LANGUAGE = "L2 language";
    public const string FACET_L2_MODE = "L2 mode"; //dubbed, subtitled

    public const string FACET_L2_SAME_AS_L3ST = "L2 same as L3ST"; //TODO: maybe this can be autocalculated using (L2language == L3SToccurrence.L3STlanguage) ?

    public const string FACET_L3ST_CONVEYED_AS_L3TT = "L3ST conveyed as L3TT";

    public const string FACET_L3TT_LANGUAGE_TYPE = "L3TT language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3TT_LANGUAGE = "L3TT language";

    public const string FACET_L3TT_CONSTRUCTED_BASED_ON = "L3TT constructed based on";

    public const string FACET_L3TT_AUDIENCE_UNDERSTANDING = "L3TT meant to be understood";
    public const string FACET_L3TT_MESSAGE_UNDERSTANDING = "L3TT required for understanding";
    public const string FACET_L3TT_MEANING_DECIPHERABLE = "L3TT meaning decipherable";

    public const string FACET_L3TT_SPEAKER_PERFORMANCE = "L3TT speaker performance";

    public const string FACET_L3TT_MODE = "L3TT mode";

    public const string FACET_L3TT_REPRESENTED = "L3 represented";
    public const string FACET_L3TT_REPRESENTATIONS_ORAL = "L3 oral representations";
    public const string FACET_L3TT_REPRESENTATIONS_VISUAL = "L3 visual representations";

    public const string FACET_L3TT_FUNCTIONS = "L3 functions";

    //Calculatable from L3SToccurrence//

    public const string FACET_L3ST_MODE_CHANGE = "L3ST mode change";
    public const string FACET_L3ST_FUNCTIONS_CHANGE = "L3ST functions change";

  }

}