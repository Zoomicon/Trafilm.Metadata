//Project: Trafilm (http://Trafilm.codeplex.com)
//Filename: TrafilmMetadtata.cs
//Version: 20140410

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
    public string Filename { get; set; }
    public DateTime FirstPublished { get; set; }
    public DateTime LastUpdated { get; set; }
    public string[] AgeGroup { get; set; }
    public string[] Keywords { get; set; }
    public string[] AuthorSource { get; set; }
    public string License { get; set; }

    #endregion

    #region --- Load ---

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      Filename = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_FILENAME);
      FirstPublished = facets.CXMLFacetDateTimeValue(TrafilmMetadataFacets.FACET_FIRST_PUBLISHED);
      LastUpdated = facets.CXMLFacetDateTimeValue(TrafilmMetadataFacets.FACET_LAST_UPDATED);

      AgeGroup = facets.CXMLFacetStringValues(TrafilmMetadataFacets.FACET_AGE_GROUP);
      Keywords = facets.CXMLFacetStringValues(TrafilmMetadataFacets.FACET_KEYWORDS);
      AuthorSource = facets.CXMLFacetStringValues(TrafilmMetadataFacets.FACET_AUTHORS_SOURCE);
      License = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_LICENSE);

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
        Id = Filename;
      
      if (string.IsNullOrWhiteSpace(Title)) //also checks for empty string
        Title = Filename;
      
      return this;
    }

    #endregion

    public override void Clear()
    {
      base.Clear();
 
      //Facets//
      Filename = "";
      FirstPublished = DateTime.UtcNow;
      LastUpdated = DateTime.UtcNow;

      AgeGroup = new string[] { };
      Keywords = new string[] { };
      AuthorSource = new string[] { };
      License = "";
    }

    #region --- Helpers ---

    public static XElement FindItem(string key, XDocument doc)
    {
      return doc.Root.Elements(CXML.NODE_ITEMS).Elements(CXML.NODE_ITEM).CXMLFirstItemWithStringValue(TrafilmMetadataFacets.FACET_FILENAME, key);
    }

    public static XElement MakeAgeGroupFacetCategory()
    {
      return
        new XElement(CXML.NODE_FACET_CATEGORY,
          new XAttribute(CXML.ATTRIB_NAME, TrafilmMetadataFacets.FACET_AGE_GROUP),
          new XAttribute(CXML.ATTRIB_TYPE, "String"),
          new XAttribute(CXML.ATTRIB_IS_FILTER_VISIBLE, "True"),
          new XAttribute(CXML.ATTRIB_IS_METADATA_VISIBLE, "True"),
          new XAttribute(CXML.ATTRIB_IS_WORD_WHEEL_VISIBLE, "True"),

          new XElement(CXML.NODE_EXTENSION,
            new XElement(CXML.NODE_SORT_ORDER,
              new XAttribute(CXML.ATTRIB_NAME, TrafilmMetadataFacets.FACET_AGE_GROUP),

              new XElement(CXML.NODE_SORT_VALUE,
                new XAttribute(CXML.ATTRIB_VALUE, "All ages")),
              new XElement(CXML.NODE_SORT_VALUE,
                new XAttribute(CXML.ATTRIB_VALUE, "< 13 years old")),
              new XElement(CXML.NODE_SORT_VALUE,
                new XAttribute(CXML.ATTRIB_VALUE, "13 - 18 years old")),
              new XElement(CXML.NODE_SORT_VALUE,
                new XAttribute(CXML.ATTRIB_VALUE, "18 - 35 years old")),
              new XElement(CXML.NODE_SORT_VALUE,
                new XAttribute(CXML.ATTRIB_VALUE, "> 35 years old"))
            )
          )
        );
    }

    #endregion

  }

}