//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3occurence.cs
//Version: 20160503

namespace Trafilm.Metadata.Models
{

  public interface IL3occurence : IL3occurenceMetadata
  {

    #region --- Properties ---

    IConversation Conversation { get; set; }

    #endregion

  }

}