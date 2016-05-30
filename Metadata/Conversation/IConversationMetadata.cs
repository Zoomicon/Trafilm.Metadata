//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IConversationMetadata.cs
//Version: 20160525

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
    string L3STspeakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3

    //Calculatable from L3STinstances//

    int L3STlanguagesCount { get; set; }
    string[] L3STlanguages { get; set; }

    int L3STlanguageTypesCount { get; set; }
    string[] L3STlanguageTypes { get; set; }

    int L3STinstanceCount { get; set; }

    #endregion

  }

}