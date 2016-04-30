﻿//Project: Trafilm (http://trafilm.net)
//Filename: ITrafilmMetadata.cs
//Version: 20160429

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
    string Comments { get; set; }

    #endregion

  }

}