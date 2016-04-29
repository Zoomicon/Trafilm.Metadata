//Project: Trafilm (http://Trafilm.codeplex.com)
//Filename: ISceneMetadata.cs
//Version: 20160429

namespace Trafilm.Metadata
{

  public interface ISceneMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    //...

    string UtteranceCount { get; set; }

    #endregion

  }

}