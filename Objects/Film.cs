//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Film.cs
//Version: 20160503

using Trafilm.Metadata.Models;

using System.Collections.Generic;

namespace Trafilm.Metadata
{

  public class Film : FilmMetadata, IFilm
  {

    #region --- Properties ---

    public IEnumerable<IConversation> Conversations { get; set; }

    #endregion

  }

}