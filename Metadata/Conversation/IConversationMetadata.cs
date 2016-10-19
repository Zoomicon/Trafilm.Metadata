﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IConversationMetadata.cs
//Version: 20161017

using System;

namespace Trafilm.Metadata.Models
{

  public interface IConversationMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    string FilmOrSeasonTitle { get; set; } //Calculatable from Film
    string SeasonEpisodeName { get; set; }

    int? StartTime { get; set; } //in min
    string Duration { get; set; } //in sec spans

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