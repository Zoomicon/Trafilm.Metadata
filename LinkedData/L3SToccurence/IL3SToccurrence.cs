//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3SToccurrence.cs
//Version: 20160524

namespace Trafilm.Metadata.Models
{

  public interface IL3SToccurrence : IL3SToccurrenceMetadata
  {

    #region --- Properties ---

    IConversation Conversation { get; set; }

    #endregion

  }

}