//Project: Trafilm (http://trafilm.net)
//Filename: ILinkedSceneMetadata.cs
//Version: 20160503

using System.Collections.Generic;

namespace Trafilm.Metadata.Models
{

  public interface ILinkedSceneMetadata : ISceneMetadata
  {

    #region --- Properties ---

    IFilmMetadata Film { get; set; }
    IEnumerable<ISceneMetadata> Utterances { get; set; }

    #endregion

  }

}