//Project: Trafilm (http://trafilm.net)
//Filename: ISceneMetadata.cs
//Version: 20160503

using System;

namespace Trafilm.Metadata.Models
{

  public interface ISceneMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    TimeSpan? StartTime { get; set; }
    TimeSpan? Duration { get; set; }

    bool L1sourceLanguagePresent { get; set; }
    bool L2translatedLanguagePresent { get; set; }

    string SpeakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3
    string L3speakingCharactersCount { get; set; } //e.g. 1, 2, 3, more than 3

    //Calculatable from Utterances//

    int L3otherLanguagesCount { get; set; }
    string[] L3otherLanguages { get; set; }

    int L3otherTypesCount { get; set; }
    string[] L3otherTypes { get; set; }

    int UtteranceCount { get; set; }

    #endregion

  }

}