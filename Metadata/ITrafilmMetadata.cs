//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ITrafilmMetadata.cs
//Version: 20160608

using Metadata.CXML;

using System;

namespace Trafilm.Metadata
{

  public interface ITrafilmMetadata : ICXMLMetadata
  {

    #region --- Properties ---

    //Facets//
    string ReferenceId { get; set; } //PivotViewer collection tools seem to generate sequential IDs, so we need a separate Code to reference an item

    string Transcription { get; set; }

    string[] Keywords { get; set; }

    string Remarks { get; set; }

    DateTime InfoCreated { get; set; }
    DateTime InfoUpdated { get; set; }

    string[] MetadataEditors { get; set; }

    #endregion

    #region --- Methods ---

    void ClearCalculated();

    #endregion

  }

}