//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IConversationMetadata.cs
//Version: 20160614

using System;

namespace Trafilm.Metadata.Models
{

  public interface IConversationMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    TimeSpan? StartTime { get; set; }
    TimeSpan? Duration { get; set; }

    string LanguageSources { get; set; }

    //Calculatable from L3STinstances//

    int L3STlanguagesCount { get; set; }
    string[] L3STlanguages { get; set; }

    int L3STlanguageTypesCount { get; set; }
    string[] L3STlanguageTypes { get; set; }

    int L3STinstanceCount { get; set; }

    #endregion

  }

}