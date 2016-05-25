//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Conversation.cs
//Version: 20160525

using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Linq;

namespace Trafilm.Metadata
{

  public class Conversation : ConversationMetadata, IConversation
  {

    #region --- Fields ---

    protected IEnumerable<IL3SToccurrence> l3stOccurrences; //=null

    #endregion

    #region --- Properties ---

    public IFilm Film { get; set; }
    public IEnumerable<IL3SToccurrence> L3SToccurrences
    {
      get
      {
        return l3stOccurrences;
      }
      set
      {
        l3stOccurrences = value;

        //Calculated from L3SToccurrences//

        if (value != null)
        {
          L3SToccurrenceCount = value.Count();

          L3STlanguages = value.Aggregate(new List<string>(), (total, next) => { if (!string.IsNullOrEmpty(next.L3STlanguage) && !total.Contains(next.L3STlanguage)) total.Add(next.L3STlanguage); return total; } ).ToArray();
          L3STlanguagesCount = L3STlanguages.Count();

          L3STlanguageTypes = value.Aggregate(new List<string>(), (total, next) => { if (!string.IsNullOrEmpty(next.L3STlanguageType) && !total.Contains(next.L3STlanguageType)) total.Add(next.L3STlanguageType); return total; }).ToArray();
          L3STlanguageTypesCount = L3STlanguageTypes.Count();
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}