//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IFilmMetadata.cs
//Version: 20160527

using System;

namespace Trafilm.Metadata.Models
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string Title_es { get; set; }
    string Title_ca { get; set; }
    //...

    TimeSpan? Duration { get; set; }

    string[] Directors { get; set; }
    string[] Scriptwriters { get; set; }

    string[] ProductionCountries { get; set; }
    string[] ProductionCompanies { get; set; }

    string BoxOffice { get; set; }
    int? YearSTreleased { get; set; }

    string L1language { get; set; }

    int? YearTTreleased_Spain { get; set; }

    //Calculatable from Conversations.L3STinstances.L3TTinstances//

    string[] L2dubbedLanguages { get; set; }
    string[] L2subtitledLanguages { get; set; }

    //Calculatable from Conversations//

    int ConversationCount { get; set; }
    TimeSpan? ConversationsDuration { get; set; }

    #endregion

  }

}