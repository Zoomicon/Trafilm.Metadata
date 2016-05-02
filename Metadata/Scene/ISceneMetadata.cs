//Project: Trafilm (http://trafilm.net)
//Filename: ISceneMetadata.cs
//Version: 20160503

using System;

namespace Trafilm.Metadata
{

  public interface ISceneMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    TimeSpan? StartTime { get; set; }
    TimeSpan? Duration { get; set; }

    bool L1sourceLanguagePresent { get; set; }
    bool L2translatedLanguagePresent { get; set; }

    //Calculatable//

    int L3otherLanguagesCount { get; set; }
    string[] L3otherLanguages { get; set; }

    int UtteranceCount { get; set; }

    #endregion

  }

}