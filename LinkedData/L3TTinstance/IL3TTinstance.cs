//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3TTinstance.cs
//Version: 20160530

namespace Trafilm.Metadata.Models
{

  public interface IL3TTinstance : IL3TTinstanceMetadata
  {

    #region --- Properties ---

    IL3STinstance L3STinstance { get; set; }

    #endregion

  }

}