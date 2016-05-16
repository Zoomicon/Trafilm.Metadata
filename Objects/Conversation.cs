//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Conversation.cs
//Version: 20160503

using Trafilm.Metadata.Models;

using System.Collections.Generic;

namespace Trafilm.Metadata
{

  public class Conversation : ConversationMetadata, IConversation
  {

    #region --- Properties ---

    public IFilm Film { get; set; }
    public IEnumerable<IL3occurence> L3occurences { get; set; }

    #endregion

  }

}