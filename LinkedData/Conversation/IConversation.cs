//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IConversation.cs
//Version: 20160503

using System.Collections.Generic;

namespace Trafilm.Metadata.Models
{

  public interface IConversation : IConversationMetadata
  {

    #region --- Properties ---

    IFilm Film { get; set; }
    IEnumerable<IL3SToccurrence> L3SToccurrences { get; set; }

    #endregion

  }

}