//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3SToccurrenceMetadata.cs
//Version: 20160529

using System;

namespace Trafilm.Metadata.Models
{

  public interface IL3SToccurrenceMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }
    string ConversationReferenceId { get; set; }

    TimeSpan? StartTime { get; set; }
    TimeSpan? Duration { get; set; }

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

    //Calculatable from L3TToccurrences//

    int L3TToccurrenceCount { get; set; }

    #endregion

  }

}