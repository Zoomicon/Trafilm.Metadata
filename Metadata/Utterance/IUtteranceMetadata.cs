//Project: Trafilm (http://trafilm.net)
//Filename: IUtteranceMetadata.cs
//Version: 20160501

namespace Trafilm.Metadata.Models
{

  public interface IUtteranceMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string SceneReferenceId { get; set; }

    //...

    #endregion

  }

}