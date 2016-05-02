//Project: Trafilm (http://trafilm.net)
//Filename: ISceneMetadata.cs
//Version: 20160502

namespace Trafilm.Metadata
{

  public interface ISceneMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    //...

    int UtteranceCount { get; set; }

    #endregion

  }

}