//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3STinstance.cs
//Version: 20160530

using System.Collections.Generic;

namespace Trafilm.Metadata.Models
{

  public interface IL3STinstance : IL3STinstanceMetadata
  {

    #region --- Properties ---

    IConversation Conversation { get; set; }
    IEnumerable<IL3TTinstance> L3TTinstances { get; set; }

    #endregion

  }

}