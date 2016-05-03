//Project: Trafilm (http://trafilm.net)
//Filename: IFilm.cs
//Version: 20160503

using System.Collections.Generic;

namespace Trafilm.Metadata.Models
{

  public interface IFilm : IFilmMetadata
  {

    #region --- Properties ---

    IEnumerable<IScene> Scenes { get; set; }

    #endregion

  }

}