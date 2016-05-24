//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3occurrence.cs
//Version: 20160524

using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3occurrence : L3occurrenceMetadata, IL3occurrence
  {

    #region --- Properties ---

    public IConversation Conversation { get; set; }

    #endregion

  }

}