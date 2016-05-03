//Project: Trafilm (http://trafilm.net)
//Filename: Scene.cs
//Version: 20160503

using Trafilm.Metadata.Models;

using System.Collections.Generic;

namespace Trafilm.Metadata
{

  public class Scene : SceneMetadata, IScene
  {

    #region --- Properties ---

    public IFilm Film { get; set; }
    public IEnumerable<IUtterance> Utterances { get; set; }

    #endregion

  }

}