//Project: Trafilm (http://trafilm.net)
//Filename: UtteranceMetadata.cs
//Version: 20160504

using Metadata.CXML;
using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Xml.Linq;

namespace Trafilm.Metadata
{

  public class UtteranceMetadata : TrafilmMetadata, IUtteranceMetadata
  {

    #region --- Properties ---

    public string FilmReferenceId { get; set; }
    public string SceneReferenceId { get; set; }

    public string L3type { get; set; } //L3ST, L3TT

    public string LmainLanguage { get; set; } //for L1ST or L2TT

    public string L3languageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    public string L3language { get; set; }

    public string[] L3constructedBasedOn { get; set; }

    public string L3audienceUnderstanding { get; set; }
    public string L3messageUnderstanding { get; set; }

    public string L3speakerPerformance { get; set; }

    public string[] L3mode { get; set; } //oral, written (or both)
    public string L3STmodeChange { get; set; } //Only for L3TT type, for L3ST should always be "Does not apply"

    public string[] L3represented { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      FilmReferenceId = "";
      SceneReferenceId = "";

      L3type = "";

      LmainLanguage = "";

      L3languageType = "";
      L3language = "";

      L3constructedBasedOn = new string[] { };

      L3audienceUnderstanding = "";
      L3messageUnderstanding = "";

      L3speakerPerformance = "";

      L3mode = new string[] { };

      L3STmodeChange = "";

      L3represented = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      SceneReferenceId = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_SCENE_REFERENCE_ID);

      //...

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeUtteranceFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets(IList<XElement> facets = null)
    {
      if (facets == null)
        facets = new List<XElement>();

      base.GetCXMLFacets(facets);


      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_SCENE_REFERENCE_ID, SceneReferenceId));

      //...

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeUtteranceFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: false, isMetadataVisible: false, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_SCENE_REFERENCE_ID, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      //...

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_CREATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_INFO_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}