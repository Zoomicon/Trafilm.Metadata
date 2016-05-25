//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TToccurrence.cs
//Version: 20160525

using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3TToccurrence : L3TToccurrenceMetadata, IL3TToccurrence
  {

    #region --- Properties ---

    public IL3SToccurrence L3SToccurrence { get; set; } //TODO: update calculate fields from parent (see Conversation object)

    #endregion

  }

}