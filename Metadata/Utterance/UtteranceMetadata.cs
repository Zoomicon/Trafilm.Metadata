//Project: Trafilm (http://Trafilm.codeplex.com)
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

    public string[] AudioLanguage { get; set; }
    public string[] CaptionsLanguage { get; set; }
    public string[] Genre { get; set; }
    public string Duration { get; set; }
    public string[] AudiovisualRichness { get; set; }

    #endregion

    #region --- Methods ---

    public override void Clear()
    {
      base.Clear();

      AudioLanguage = new string[] { };
      CaptionsLanguage = new string[] { };
      Genre = new string[] { };
      Duration = "0:0:0";
      AudiovisualRichness = new string[] { };
    }

    public override ICXMLMetadata Load(XElement item)
    {
      base.Load(item);

      IEnumerable<XElement> facets = FindFacets(item);

      AudioLanguage = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_AUDIO_LANGUAGE);
      CaptionsLanguage = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_CAPTIONS_LANGUAGE);
      Genre = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_GENRE);
      Duration = facets.CXMLFacetStringValue(UtteranceMetadataFacets.FACET_DURATION);
      AudiovisualRichness = facets.CXMLFacetStringValues(UtteranceMetadataFacets.FACET_AUDIOVISUAL_RICHNESS);

      return this;
    }

    public override IEnumerable<XElement> GetCXMLFacetCategories() //the following also defines the order in which facets appear in PivotViewer's filters pane
    {
      return MakeUtteranceFacetCategories();
    }

    public override IEnumerable<XElement> GetCXMLFacets()
    {
      IList<XElement> facets = new List<XElement>();

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_FILENAME, Filename));

      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_AUDIO_LANGUAGE, AudioLanguage));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_CAPTIONS_LANGUAGE, CaptionsLanguage));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_GENRE, Genre));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_DURATION, Duration));
      AddNonNullToList(facets, CXML.MakeStringFacet(UtteranceMetadataFacets.FACET_AUDIOVISUAL_RICHNESS, AudiovisualRichness));

      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_AGE_GROUP, AgeGroup)); 
      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_KEYWORDS, Keywords));
      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_AUTHORS_SOURCE, AuthorSource));
      AddNonNullToList(facets, CXML.MakeStringFacet(TrafilmMetadataFacets.FACET_LICENSE, License));

      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_FIRST_PUBLISHED, FirstPublished));
      AddNonNullToList(facets, CXML.MakeDateTimeFacet(TrafilmMetadataFacets.FACET_LAST_UPDATED, LastUpdated));

      return facets;
    }

    #endregion

    #region --- Helpers ---

    public static IEnumerable<XElement> MakeUtteranceFacetCategories() //the following also defines the order in which filters appear in PivotViewer's filter pane
    {
      IList<XElement> result = new List<XElement>();
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_FILENAME, CXML.VALUE_STRING, null,isFilterVisible: false, isMetadataVisible: false, isWordWheelVisible: false));

      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_AUDIO_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_CAPTIONS_LANGUAGE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_GENRE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_DURATION, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(UtteranceMetadataFacets.FACET_AUDIOVISUAL_RICHNESS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(MakeAgeGroupFacetCategory());
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_KEYWORDS, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_AUTHORS_SOURCE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_LICENSE, CXML.VALUE_STRING, null, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: true));

      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_FIRST_PUBLISHED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: false, isMetadataVisible: true, isWordWheelVisible: false));
      result.Add(CXML.MakeFacetCategory(TrafilmMetadataFacets.FACET_LAST_UPDATED, CXML.VALUE_DATETIME, CXML.DEFAULT_DATETIME_FORMAT, isFilterVisible: true, isMetadataVisible: true, isWordWheelVisible: false));

      return result;
    }

    #endregion

  }

}