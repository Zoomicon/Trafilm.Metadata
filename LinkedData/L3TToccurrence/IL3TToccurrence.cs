//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3TToccurrence.cs
//Version: 20160525

namespace Trafilm.Metadata.Models
{

  public interface IL3TToccurrence : IL3TToccurrenceMetadata
  {

    #region --- Properties ---

    IL3SToccurrence L3SToccurrence { get; set; }

    #endregion

  }

}