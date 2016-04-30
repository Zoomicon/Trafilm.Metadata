//Project: Trafilm (http://trafilm.net)
//Filename: IFilmMetadata.cs
//Version: 20160429

namespace Trafilm.Metadata
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string Title_source { get; set; }
    string Title_es { get; set; }
    string Title_ca { get; set; }
    //...

    string Director { get; set; }
    string Scriptwriter { get; set; }

    string ProductionCountry { get; set; }
    string ProductionCompany { get; set; }

    string Duration { get; set; }

    string[] SourceLanguage { get; set; }
    string[] DubbedLanguage { get; set; }
    string[] SubtitledLanguage { get; set; }

    string SceneCount { get; set; }

    #endregion

  }

}