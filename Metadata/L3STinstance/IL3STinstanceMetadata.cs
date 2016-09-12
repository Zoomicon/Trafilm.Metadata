//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3STinstanceMetadata.cs
//Version: 20160912

using System;

namespace Trafilm.Metadata.Models
{

  public interface IL3STinstanceMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }
    string ConversationReferenceId { get; set; }

    int? StartTime { get; set; } //in minutes //Calculatable from Conversation
    int? Duration { get; set; } //in minutes //Calculatable from Conversation

    string L1language { get; set; } //Calculatable from Film

    string L3STlanguageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    string L3STlanguage { get; set; }

    string[] L3STconstructedBasedOn { get; set; }

    string L3STaudienceUnderstanding { get; set; }
    string L3STmessageUnderstanding { get; set; }
    string L3STmeaningDecipherable { get; set; }
    
    string L3STspeakerPerformance { get; set; }

    string[] L3STmode { get; set; }

    string[] L3STrepresented { get; set; }
    string[] L3STrepresentationsOral { get; set; }
    string[] L3STrepresentationsVisual { get; set; }

    string[] L3STfunctions { get; set; }
    string[] L3STconversationFeatures { get; set; }

    string L3STsources { get; set; }

    //Calculatable from L3TTinstances//

    int L3TTinstanceCount { get; set; }

    #endregion

  }

}