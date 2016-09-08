//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IFilmMetadata.cs
//Version: 20160906

using System;

namespace Trafilm.Metadata.Models
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string Title_es { get; set; }
    string Title_ca { get; set; }
    //...

    int? Duration { get; set; } //in minutes

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
    int? ConversationsDuration { get; set; } //in minutes

    #endregion

  }

}