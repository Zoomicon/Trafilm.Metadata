//Project: Trafilm (http://Trafilm.codeplex.com)
//Filename: ITrafilmMetadata.cs
//Version: 20131101

using Metadata.CXML;

using System;

namespace Trafilm.Metadata
{

  public interface ITrafilmMetadata : ICXMLMetadata
  {

    #region --- Properties ---

    //Facets//
    string Filename { get; set; }
    DateTime FirstPublished { get; set; }
    DateTime LastUpdated { get; set; }

    string[] AgeGroup { get; set; }
    string[] Keywords { get; set; }
    string[] AuthorSource { get; set; }
    string License { get; set; }

    #endregion

  }

}