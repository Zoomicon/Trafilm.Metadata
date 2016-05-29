//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3SToccurrence.cs
//Version: 20160529

using System.Collections.Generic;
using System.Linq;
using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3SToccurrence : L3SToccurrenceMetadata, IL3SToccurrence
  {

    #region --- Fields ---

    protected IConversation conversation; //=null
    protected IEnumerable<IL3TToccurrence> l3TToccurrences; //=null

    #endregion

    #region --- Properties ---

    public IConversation Conversation
    {
      get
      {
        return Conversation;
      }
      set
      {
        conversation = value;

        //Calculated from Film//

        if ((value != null) && (value.Film != null))
        {
          L1language = value.Film.L1language;
          //...
        }
        else
          ClearCalculatedFromFilm(); //con't call ClearCalculated() here, since we also calculate facet values at "L3TToccurrences" property
      }
    }

    public IEnumerable<IL3TToccurrence> L3TToccurrences
    {
      get
      {
        return l3TToccurrences;
      }
      set
      {
        l3TToccurrences = value;

        //Calculated from L3TToccurrences//

        if (value != null)
        {
          L3TToccurrenceCount = value.Count();
          //...
        }
        else
          ClearCalculatedFromL3TToccurrences(); //con't call ClearCalculated() here, since we also calculate facet values at "Conversation" property
      }
    }

    #endregion

  }

}