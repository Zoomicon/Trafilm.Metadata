//Project: Trafilm (http://trafilm.net)
//Filename: TrafilmMetadtata.cs
//Version: 20160429

using Metadata.CXML;

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public abstract class TrafilmMetadata : CXMLMetadata, ITrafilmMetadata
  {

    #region --- Properties ---
   
    //Facets//
    public string ReferenceId { get; set; }
    public DateTime InfoCreated { get; set; }
    public DateTime InfoUpdated { get; set; }
    public string[] Keywords { get; set; }
    public string Comments { get; set; }

    #endregion

    #region --- Methods ---

    public override ICXMLMetadata Fix()
    {
      if (string.IsNullOrWhiteSpace(Id)) //also checks for empty string
        Id = ReferenceId;

      return this;
    }

    public override void Clear()
    {
      base.Clear();

      //Facets//
      ReferenceId = "";
      InfoCreated = DateTime.UtcNow;
      InfoUpdated = DateTime.UtcNow;

      Keywords = new string[] { };
      Comments = "";
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      ReferenceId = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_REFERENCE_ID);
      InfoCreated = facets.CXMLFacetDateTimeValue(TrafilmMetadataFacets.FACET_INFO_CREATED);
      InfoUpdated = facets.CXMLFacetDateTimeValue(TrafilmMetadataFacets.FACET_INFO_UPDATED);

      Keywords = facets.CXMLFacetStringValues(TrafilmMetadataFacets.FACET_KEYWORDS);
      Comments = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_COMMENTS);

      return this;
    }

    public override ICXMLMetadata Load(string key, XDocument doc)
    {
      try
      {
        XElement item = FindItem(key, doc);
        Load(item);
        Fix();
      }
      catch
      {
        Clear();
      }

      return this;
    }

    public override ICXMLMetadata Load(string key, XmlReader cxml, XmlReader cxmlFallback)
    {
      return ((ITrafilmMetadata)base.Load(key, cxml, cxmlFallback));
    }

    public override IEnumerable<XElement> GetCXMLFacets()
    {
      return GetCXMLFacets(null);
    }

    public virtual IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_REFERENCE_ID, ReferenceId));

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_KEYWORDS, Keywords));
      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_COMMENTS, Comments));

      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_INFO_CREATED, InfoCreated));
      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_INFO_UPDATED, InfoUpdated));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static XElement FindItem(string key, XDocument doc)
    {
      return doc.Root.Elements(CXML.NODE_ITEMS).Elements(CXML.NODE_ITEM).CXMLFirstItemWithStringValue(TrafilmMetadataFacets.FACET_REFERENCE_ID, key);
    }

    #endregion

  }

}