//Project: Trafilm.Metadata (http://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Film.cs
//Version: 20160503

using Trafilm.Metadata.Models;

using System.Collections.Generic;

namespace Trafilm.Metadata
{

  public class Film : FilmMetadata, IFilm
  {

    #region --- Properties ---

    public IEnumerable<IScene> Scenes { get; set; }

    #endregion

  }

}