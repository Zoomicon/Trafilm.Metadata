//Project: Trafilm (http://trafilm.net)
//Filename: IFilmMetadata.cs
//Version: 20160501

namespace Trafilm.Metadata
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string Title_es { get; set; }
    string Title_ca { get; set; }
    //...

    string Duration { get; set; }

    string[] Directors { get; set; }
    string[] Scriptwriters { get; set; }

    string[] ProductionCountries { get; set; }
    string[] ProductionCompanies { get; set; }

    string BoxOffice { get; set; }
    string Year { get; set; }

    string[] SourceLanguages { get; set; }

    string YearTranslated { get; set; }
    string[] DubbedLanguages { get; set; }
    string[] SubtitledLanguages { get; set; }

    string SceneCount { get; set; }
    string ScenesDuration { get; set; }

    #endregion

  }

}