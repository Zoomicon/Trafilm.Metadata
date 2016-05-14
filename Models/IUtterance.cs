//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IUtterance.cs
//Version: 20160503

namespace Trafilm.Metadata.Models
{

  public interface IUtterance : IUtteranceMetadata
  {

    #region --- Properties ---

    IScene Scene { get; set; }

    #endregion

  }

}