//Project: Trafilm (http://Trafilm.codeplex.com)
//Filename: IFilmMetadata.cs
//Version: 20160428

namespace Trafilm.Metadata
{

  public interface IFilmMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string[] AudioLanguage { get; set; }
    string[] CaptionsLanguage { get; set; }
    string[] Genre { get; set; }
    string Duration { get; set; }
    string[] AudiovisualRichness { get; set; }

    #endregion

  }

}