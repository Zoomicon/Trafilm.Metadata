//Project: Trafilm (http://trafilm.net)
//Filename: ISceneMetadata.cs
//Version: 20160501

namespace Trafilm.Metadata
{

  public interface ISceneMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }

    //...

    string UtteranceCount { get; set; }

    #endregion

  }

}