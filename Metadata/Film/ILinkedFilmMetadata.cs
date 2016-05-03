//Project: Trafilm (http://trafilm.net)
//Filename: ILinkedFilmMetadata.cs
//Version: 20160503

using System.Collections.Generic;

namespace Trafilm.Metadata.Models
{

  public interface ILinkedFilmMetadata : IFilmMetadata
  {

    #region --- Properties ---

    IEnumerable<ISceneMetadata> Scenes { get; set; }

    #endregion

  }

}