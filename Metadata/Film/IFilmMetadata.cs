//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IFilmMetadata.cs
//Version: 20160908

using System;

namespace Trafilm.Metadata.Models
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    int? Duration { get; set; } //in minutes

    string[] Directors { get; set; }
    string[] Scriptwriters { get; set; }

    string[] ProductionCountries { get; set; }
    string[] ProductionCompanies { get; set; }

    string BoxOffice { get; set; }
    int? YearSTreleased { get; set; }

    string L1language { get; set; }

    //Calculatable from Conversations.L3STinstances.L3TTinstances//

    string[] L2dubbedLanguages { get; set; }
    string[] L2subtitledLanguages { get; set; }

    //Calculatable from Conversations//

    int ConversationCount { get; set; }
    int? ConversationsDuration { get; set; } //in minutes

    #endregion

  }

}