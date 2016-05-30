//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3STinstance.cs
//Version: 20160530

using System.Collections.Generic;
using System.Linq;
using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3STinstance : L3STinstanceMetadata, IL3STinstance
  {

    #region --- Fields ---

    protected IConversation conversation; //=null
    protected IEnumerable<IL3TTinstance> l3TTinstances; //=null

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
          ClearCalculatedFromFilm(); //con't call ClearCalculated() here, since we also calculate facet values at "L3TTinstances" property
      }
    }

    public IEnumerable<IL3TTinstance> L3TTinstances
    {
      get
      {
        return l3TTinstances;
      }
      set
      {
        l3TTinstances = value;

        //Calculated from L3TTinstances//

        if (value != null)
        {
          L3TTinstanceCount = value.Count();
          //...
        }
        else
          ClearCalculatedFromL3TTinstances(); //con't call ClearCalculated() here, since we also calculate facet values at "Conversation" property
      }
    }

    #endregion

  }

}