//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IScene.cs
//Version: 20160503

using System.Collections.Generic;

namespace Trafilm.Metadata.Models
{

  public interface IScene : ISceneMetadata
  {

    #region --- Properties ---

    IFilm Film { get; set; }
    IEnumerable<IUtterance> Utterances { get; set; }

    #endregion

  }

}