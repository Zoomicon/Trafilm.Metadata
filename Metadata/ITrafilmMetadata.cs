//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: ITrafilmMetadata.cs
//Version: 20160430

using Metadata.CXML;

using System;

namespace Trafilm.Metadata
{

  public interface ITrafilmMetadata : ICXMLMetadata
  {

    #region --- Properties ---

    //Facets//
    string ReferenceId { get; set; } //PivotViewer collection tools seem to generate sequential IDs, so we need a separate Code to reference an item

    DateTime InfoCreated { get; set; }
    DateTime InfoUpdated { get; set; }

    string[] Keywords { get; set; }

    #endregion

  }

}