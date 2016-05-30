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

    protected IEnumerable<IL3STinstance> l3STInstances; //=null

    #endregion

    #region --- Properties ---

    public IFilm Film { get; set; }

    public IEnumerable<IL3STinstance> L3STinstances
    {
      get
      {
        return l3STInstances;
      }
      set
      {
        l3STInstances = value;

        //Calculated from L3STinstances//

        if (value != null)
        {
          L3STinstanceCount = value.Count();

          IList<string> languages = new List<string>();
          IList<string> languageTypes = new List<string>();
          foreach(L3STinstance l3STinstance in L3STinstances)
            if (l3STinstance != null)
            {
              string language = l3STinstance.L3STlanguage;
              if (!string.IsNullOrEmpty(language) &&
                  !languages.Contains(language))
                languages.Add(language);

              string languageType = l3STinstance.L3STlanguageType;
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