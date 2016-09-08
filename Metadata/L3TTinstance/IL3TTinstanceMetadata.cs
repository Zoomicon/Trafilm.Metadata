//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3TTinstanceMetadata.cs
//Version: 20160908

namespace Trafilm.Metadata.Models
{

  public interface IL3TTinstanceMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }
    string ConversationReferenceId { get; set; }
    string L3STinstanceReferenceId { get; set; }

    int? StartTime { get; set; } //in minutes //Calculatable from L3STinstance
    int? Duration { get; set; } //in minutes //Calculatable from L3STinstance

    string L2language { get; set; }
    string L2mode { get; set; } //dubbed, subtitled

    string L2sameAsL3ST { get; set; }

    string L3STconveyedAsL3TT { get; set; }

    string L3TTlanguageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    string L3TTlanguage { get; set; }

    string[] L3TTconstructedBasedOn { get; set; }

    string L3TTaudienceUnderstanding { get; set; }
    string L3TTmessageUnderstanding { get; set; }
    string L3TTmeaningDecipherable { get; set; }
    
    string L3TTspeakerPerformance { get; set; }

    string[] L3TTmode { get; set; }

    string[] L3TTrepresented { get; set; }
    string[] L3TTrepresentationsOral { get; set; }
    string[] L3TTrepresentationsVisual { get; set; }

    string[] L3TTfunctions { get; set; }
    string[] L3TTtypesFeatures { get; set; }

    string L3TTsources { get; set; }

    //Calculatable from L3STinstance//

    string[] L3STlanguageTypeChange { get; set; }
    string[] L3STmodeChange { get; set;  }
    string[] L3STfunctionsChange { get; set; }
    string[] L3STtypesFeaturesChange { get; set; }
    string[] L3STsourcesChange { get; set; }

    #endregion

  }

}