//Project: Trafilm (http://trafilm.net)
//Filename: IFilmMetadata.cs
//Version: 20160503

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
    int? Year { get; set; }

    string[] SourceLanguages { get; set; }

    int? YearTranslated { get; set; }
    string[] DubbedLanguages { get; set; }
    string[] SubtitledLanguages { get; set; }

    //Calculatable from Scenes//

    int SceneCount { get; set; }
    TimeSpan ScenesDuration { get; set; }

    #endregion

  }

}