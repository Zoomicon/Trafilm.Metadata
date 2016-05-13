//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: UtteranceMetadataFacets.cs
//Version: 20160512

namespace Trafilm.Metadata
{

  public static class UtteranceMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";
    public const string FACET_SCENE_REFERENCE_ID = "Scene Reference Id";

    public const string FACET_L3_KIND = "L3 kind";

    public const string FACET_L_MAIN_LANGUAGE = "L1ST/L2TT"; //depending on L3 type this is either the L1ST language or the L2TT language
    public const string FACET_L_MAIN_MODE = "L main mode"; //oral, text (means dubbed, subtitled in L2TT context)

    public const string FACET_L2_SAME_AS_L3ST = "L2 same as L3ST";
    public const string FACET_L3ST_CONVEYED_AS_L3TT = "L3ST conveyed as L3TT";

    public const string FACET_L3_LANGUAGE_TYPE = "L3 language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3_LANGUAGE = "L3 language";

    public const string FACET_L3_CONSTRUCTED_BASED_ON = "L3 constructed based on";

    public const string FACET_L3_AUDIENCE_UNDERSTANDING = "L3 audience understanding";
    public const string FACET_L3_MESSAGE_UNDERSTANDING = "L3 message understanding";
    public const string FACET_L3_MEANING_DECIPHERED = "L3 meaning deciphered";

    public const string FACET_L3_SPEAKER_PERFORMANCE = "L3 speaker performance";

    public const string FACET_L3_MODE = "L3 mode";
    public const string FACET_L3ST_MODE_CHANGE = "L3ST mode change"; //for L3 type = L3ST this should always be "Not applicable"

    public const string FACET_L3_REPRESENTED = "L3 represented";
    public const string FACET_L3_REPRESENTATIONS_ORAL = "L3 oral representations";
    public const string FACET_L3_REPRESENTATIONS_VISUAL = "L3 visual representations";

    public const string FACET_L3_FUNCTIONS = "L3 functions";
  }

}