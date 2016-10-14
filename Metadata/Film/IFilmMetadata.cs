//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IFilmMetadata.cs
//Version: 20161014

using System;

namespace Trafilm.Metadata.Models
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string Type { get; set; }

    int? Duration { get; set; } //in min

    string Series { get; set; }

    string[] Directors { get; set; }
    string[] Scriptwriters { get; set; }

    string[] ProductionCountries { get; set; }
    string[] ProductionCompanies { get; set; }

    string Blockbuster { get; set; }
    int? YearSTreleased { get; set; }

    string L1language { get; set; }

    //Calculatable from Conversations.L3STinstances.L3TTinstances//

    string[] L2dubbedLanguages { get; set; }
    string[] L2subtitledLanguages { get; set; }

    //Calculatable from Conversations//

    int ConversationCount { get; set; }

    #endregion

  }

}