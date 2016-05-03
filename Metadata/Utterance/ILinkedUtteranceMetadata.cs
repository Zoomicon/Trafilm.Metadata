//Project: Trafilm (http://trafilm.net)
//Filename: ILinkedUtteranceMetadata.cs
//Version: 20160503

namespace Trafilm.Metadata.Models
{

  public interface ILinkedUtteranceMetadata : IUtteranceMetadata
  {

    #region --- Properties ---

    ISceneMetadata Scene { get; set; }

    #endregion

  }

}