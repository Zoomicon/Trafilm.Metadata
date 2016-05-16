//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3occurence.cs
//Version: 20160503

using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3occurence : L3occurenceMetadata, IL3occurence
  {

    #region --- Properties ---

    public IConversation Conversation { get; set; }

    #endregion

  }

}