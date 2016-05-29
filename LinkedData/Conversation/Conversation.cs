//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Conversation.cs
//Version: 20160529

using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Linq;

namespace Trafilm.Metadata
{

  public class Conversation : ConversationMetadata, IConversation
  {

    #region --- Fields ---

    protected IEnumerable<IL3SToccurrence> l3STOccurrences; //=null

    #endregion

    #region --- Properties ---

    public IFilm Film { get; set; }

    public IEnumerable<IL3SToccurrence> L3SToccurrences
    {
      get
      {
        return l3STOccurrences;
      }
      set
      {
        l3STOccurrences = value;

        //Calculated from L3SToccurrences//

        if (value != null)
        {
          L3SToccurrenceCount = value.Count();

          IList<string> languages = new List<string>();
          IList<string> languageTypes = new List<string>();
          foreach(L3SToccurrence l3SToccurrence in L3SToccurrences)
            if (l3SToccurrence != null)
            {
              string language = l3SToccurrence.L3STlanguage;
              if (!string.IsNullOrEmpty(language) &&
                  !languages.Contains(language))
                languages.Add(language);

              string languageType = l3SToccurrence.L3STlanguageType;
              if (!string.IsNullOrEmpty(languageType) &&
                  !languageTypes.Contains(languageType))
                languageTypes.Add(languageType);
            }
          L3STlanguages = languages.ToArray();
          L3STlanguageTypes = languageTypes.ToArray();

          L3STlanguagesCount = L3STlanguages.Count();
          L3STlanguageTypesCount = L3STlanguageTypes.Count();

          //...
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}