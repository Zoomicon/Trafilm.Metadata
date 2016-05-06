//Project: Trafilm (http://trafilm.net)
//Filename: UtteranceMetadataFacets.cs
//Version: 20160506

namespace Trafilm.Metadata
{

  public static class UtteranceMetadataFacets
  {
    public const string FACET_FILM_REFERENCE_ID = "Film Reference Id";
    public const string FACET_SCENE_REFERENCE_ID = "Scene Reference Id";

    public const string FACET_L3_TYPE = "L3 type";

    public const string FACET_L_MAIN_LANGUAGE = "L1ST/L2TT"; //depending on L3 type this is either the L1ST language or the L2TT language

    public const string FACET_L3_LANGUAGE_TYPE = "L3 language type"; //e.g. real, constructed, variety (real dialect, slang or other)
    public const string FACET_L3_LANGUAGE = "L3 language";

    public const string FACET_L3_CONSTRUCTED_BASED_ON = "L3 constructed based on";

    public const string FACET_L3_AUDIENCE_UNDERSTANDING = "L3 audience understanding";
    public const string FACET_L3_MESSAGE_UNDERSTANDING = "L3 message understanding";

    public const string FACET_L3_SPEAKER_PERFORMANCE = "L3 speaker performance";

    public const string FACET_L3_MODE = "L3 mode";
    public const string FACET_L3ST_MODE_CHANGE = "L3ST mode change"; //for L3 type = L3ST this should always be "Not applicable"

    public const string FACET_L3_REPRESENTED = "L3 represented";
  }

}