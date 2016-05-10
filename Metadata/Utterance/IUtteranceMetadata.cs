﻿//Project: Trafilm (http://trafilm.net)
//Filename: IUtteranceMetadata.cs
//Version: 20160510

namespace Trafilm.Metadata.Models
{

  public interface IUtteranceMetadata : ITrafilmMetadata
  {

    #region --- Properties ---

    string FilmReferenceId { get; set; }
    string SceneReferenceId { get; set; }
    
    string L3type { get; set; } //for L3ST, L3TT

    string LmainLanguage { get; set; } //depending on L3 type this is either the L1ST language or the L2TT language
    string LmainMode { get; set; } //oral, text (means dubbed, subtitled in L2TT context)

    bool L2sameAsL3ST { get; set; }
    bool L3STconveyedAsL3TT { get; set; }

    string L3languageType { get; set; } //e.g. real, constructed, variety (real dialect, slang or other)
    string L3language { get; set; }

    string[] L3constructedBasedOn { get; set; }

    string L3audienceUnderstanding { get; set; }
    string L3messageUnderstanding { get; set; }
    string L3meaningDeciphered { get; set; }
    
    string L3speakerPerformance { get; set; }

    string[] L3mode { get; set; } //oral, written (or both)
    string L3STmodeChange { get; set; } //for L3 type = L3ST this should always be "Not applicable"

    string[] L3represented { get; set; }
    string[] L3representationsOral { get; set; }
    string[] L3representationsVisual { get; set; }

    string[] L3functions { get; set; }

    #endregion

  }

}