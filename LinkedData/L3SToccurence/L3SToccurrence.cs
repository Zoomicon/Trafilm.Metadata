//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3SToccurrence.cs
//Version: 20160526

using System.Collections.Generic;
using System.Linq;
using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3SToccurrence : L3SToccurrenceMetadata, IL3SToccurrence
  {

    #region --- Fields ---

    protected IEnumerable<IL3TToccurrence> l3TToccurrences; //=null

    #endregion

    #region --- Properties ---

    public IConversation Conversation { get; set; }

    public IEnumerable<IL3TToccurrence> L3TToccurrences
    {
      get
      {
        return l3TToccurrences;
      }
      set
      {
        l3TToccurrences = value;

        //Calculated from L3SToccurrences//

        if (value != null)
        {
          L3TToccurrenceCount = value.Count();

          //...
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}