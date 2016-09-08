//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: TrafilmMetadtata.cs
//Version: 20160902

using Metadata.CXML;

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public abstract class TrafilmMetadata : CXMLMetadata, ITrafilmMetadata
  {

    #region --- Constants ---

    public const string VALUE_NONE = "None";

    #endregion

    #region --- Fields ---

    private string referenceId; //=null (note: Clear() will set this to "")

    #endregion

    #region --- Properties ---

    public virtual string ReferenceId //descendents can override this property to propagate change of ReferenceId where needed
    {
      get
      {
        return referenceId;
      }

      set
      {
        if (Id == referenceId)
          Id = value;

        if (Title == referenceId)
          Title = value;

        referenceId = value;
      }
    }

    public string Transcription { get; set; }

    public string[] Tags { get; set; }

    public string Remarks { get; set; }

    public DateTime InfoCreated { get; set; }
    public DateTime InfoUpdated { get; set; }

    public string[] MetadataEditors { get; set; }

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

      Transcription = "";

      Tags = new string[] { };

      Remarks = "";

      InfoCreated = DateTime.UtcNow;
      InfoUpdated = DateTime.UtcNow;

      MetadataEditors = new string[] { };

      ClearCalculated();
    }

    public virtual void ClearCalculated()
    {
      //can override at descendents
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      ReferenceId = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_REFERENCE_ID);

      Transcription = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_TRANSCRIPTION);

      Tags = facets.CXMLFacetStringValues(TrafilmMetadataFacets.FACET_TAGS);

      Remarks = facets.CXMLFacetStringValue(TrafilmMetadataFacets.FACET_REMARKS);

      InfoCreated = facets.CXMLFacetDateTimeValue(TrafilmMetadataFacets.FACET_INFO_CREATED);
      InfoUpdated = facets.CXMLFacetDateTimeValue(TrafilmMetadataFacets.FACET_INFO_UPDATED);

      MetadataEditors = facets.CXMLFacetStringValues(TrafilmMetadataFacets.FACET_METADATA_EDITORS);

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

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_TRANSCRIPTION, Transcription));

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_TAGS, Tags));

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_REMARKS, Remarks));

      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_INFO_CREATED, InfoCreated));
      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_INFO_UPDATED, InfoUpdated));

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_METADATA_EDITORS, MetadataEditors));

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