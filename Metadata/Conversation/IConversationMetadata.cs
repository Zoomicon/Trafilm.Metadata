//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IConversationMetadata.cs
//Version: 20160512

using System;

namespace Trafilm.Metadata.Models
{

  public interface IConversationMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    TimeSpan? StartTime { get; set; }
    TimeSpan? Duration { get; set; }
    
    bool L1languagePresent { get; set; }
    bool L2languagePresent { get; set; }

    string SpeakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3
    string L3speakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3

    //Calculatable from L3occurrences//

    int L3languagesCount { get; set; }
    string[] L3languages { get; set; }

    int L3languageTypesCount { get; set; }
    string[] L3languageTypes { get; set; }

    int L3occurrenceCount { get; set; }

    #endregion

  }

}