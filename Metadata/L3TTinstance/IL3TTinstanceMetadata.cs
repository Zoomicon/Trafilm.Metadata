﻿//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: IL3TTinstanceMetadata.cs
//Version: 20180423

namespace Trafilm.Metadata.Models
{

  public interface IL3TTinstanceMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    //L3TTinstance metadata (1/2)//

    string FilmTitleTT { get; set; }

    string L2language { get; set; }
    string L2mode { get; set; } //dubbed, subtitled

    string[] DistributionCountriesTT { get; set; }
    int? YearTTreleased { get; set; }
    string BlockbusterTT { get; set; }

    //Calculatable from L3STinstance//

    int? ConversationStartTime { get; set; } //in min
    string ConversationDuration { get; set; } //in sec spans

    //L3TTinstance metadata (2/2)//

    string L2sameAsL3ST { get; set; }

    string L3STconveyedAsL3TT { get; set; }

    string L3TTlanguageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    string L3TTlanguage { get; set; }

    string[] L3TTconstructedBasedOn { get; set; }

    string L3TTaudienceUnderstanding { get; set; }
    string L3TTmessageUnderstanding { get; set; }
    string L3TTmeaningDecipherable { get; set; }
    
    string L3TTspeakerPerformance { get; set; }

    string[] L3TTmode { get; set; }

    string[] L3TTrepresented { get; set; }
    string[] L3TTrepresentationsOral { get; set; }
    string[] L3TTrepresentationsVisual { get; set; }

    string[] L3TTfunctions { get; set; }
    string[] L3TTconversationFeatures { get; set; }

    string L3TTsources { get; set; }

    //Linked Data: Calculatable from L3STinstance//

    string[] L3languageTypeChange { get; set; }
    string[] L3modeChange { get; set;  }
    string[] L3functionsChange { get; set; }
    string[] L3conversationFeaturesChange { get; set; }
    string[] L3sourcesChange { get; set; }

    //Linked Data: References//
    string FilmReferenceId { get; set; }
    string ConversationReferenceId { get; set; }
    string L3STinstanceReferenceId { get; set; }

    #endregion

  }

}