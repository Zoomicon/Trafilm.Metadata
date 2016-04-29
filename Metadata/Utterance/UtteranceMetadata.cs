﻿//Project: Trafilm (http://Trafilm.codeplex.com)
//Filename: UtteranceMetadata.cs
//Version: 20160428

using Metadata.CXML;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class UtteranceMetadata : TrafilmMetadata, IUtteranceMetadata
  {

    #region --- Properties ---

    //...

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      //...
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      //...

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeUtteranceFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets()
    {
      IList<XElement> facets = new List<XElement>();

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_CODE, Code));

      //...

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_KEYWORDS, Keywords));
      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_COMMENTS, Comments));

      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_INFO_CREATED, InfoCreated));
      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_INFO_UPDATED, InfoUpdated));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeUtteranceFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_CODE, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: false, isWordWheelVisible: false));

      //...

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_COMMENTS, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}