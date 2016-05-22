//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Conversation.cs
//Version: 20160522

using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Linq;

namespace Trafilm.Metadata
{

  public class Conversation : ConversationMetadata, IConversation
  {

    #region --- Fields ---

    protected IEnumerable<IL3occurence> l3occurences; //=null

    #endregion

    #region --- Properties ---

    public IFilm Film { get; set; }
    public IEnumerable<IL3occurence> L3occurences
    {
      get
      {
        return l3occurences;
      }
      set
      {
        l3occurences = value;

        //Calculated from L3occurences//

        if (value != null)
        {
          L3occurenceCount = value.Count();

          L3languages = value.Aggregate(new List<string>(), (total, next) => { if (!string.IsNullOrEmpty(next.L3language) && !total.Contains(next.L3language)) total.Add(next.L3language); return total; } ).ToArray();
          L3languagesCount = L3languages.Count();

          L3languageTypes = value.Aggregate(new List<string>(), (total, next) => { if (!string.IsNullOrEmpty(next.L3languageType) && !total.Contains(next.L3languageType)) total.Add(next.L3languageType); return total; }).ToArray();
          L3languageTypesCount = L3languageTypes.Count();
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}