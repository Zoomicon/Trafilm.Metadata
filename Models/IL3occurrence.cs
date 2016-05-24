//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3occurrence.cs
//Version: 20160524

namespace Trafilm.Metadata.Models
{

  public interface IL3occurrence : IL3occurrenceMetadata
  {

    #region --- Properties ---

    IConversation Conversation { get; set; }

    #endregion

  }

}