//Project: Trafilm (http://Trafilm.codeplex.com)
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
    public string Code { get; set; }
    public DateTime InfoCreated { get; set; }
    public DateTime InfoUpdated { get; set; }
    public string[] Keywords { get; set; }
    public string Comments { get; set; }

    #endregion

    #region --- Load ---

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      Code = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_CODE);
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

    public override ICXMLMetadata Fix()
    {
      if (string.IsNullOrWhiteSpace(Id)) //also checks for empty string
        Id = Code;
            
      return this;
    }

    #endregion

    public override void Clear()
    {
      base.Clear();

      //Facets//
      Code = "";
      InfoCreated = DateTime.UtcNow;
      InfoUpdated = DateTime.UtcNow;

      Keywords = new string[] { };
      Comments = "";
    }

    #region --- Helpers ---

    public static XElement FindItem(string key, XDocument doc)
    {
      return doc.Root.Elements(CXML.NODE_ITEMS).Elements(CXML.NODE_ITEM).CXMLFirstItemWithStringValue(TrafilmMetadataFacets.FACET_CODE, key);
    }

    #endregion

  }

}