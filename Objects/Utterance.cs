//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Utterance.cs
//Version: 20160503

using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class Utterance : UtteranceMetadata, IUtterance
  {

    #region --- Properties ---

    public IScene Scene { get; set; }

    #endregion

  }

}