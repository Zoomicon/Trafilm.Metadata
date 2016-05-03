﻿//Project: Trafilm (http://trafilm.net)
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