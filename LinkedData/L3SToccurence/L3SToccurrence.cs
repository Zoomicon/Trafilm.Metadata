//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3SToccurrence.cs
//Version: 20160524

using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3SToccurrence : L3SToccurrenceMetadata, IL3SToccurrence
  {

    #region --- Properties ---

    public IConversation Conversation { get; set; }

    #endregion

  }

}