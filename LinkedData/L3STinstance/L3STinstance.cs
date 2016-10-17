//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3STinstance.cs
//Version: 20161017

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

    public override string ReferenceId
    {
      get
      {
        return base.ReferenceId;
      }

      set
      {
        base.ReferenceId = value; //this will also change Id and Title fields if they were equal to ReferenceId

        if (L3TTinstances != null)
          foreach (IL3TTinstance l3TTinstance in L3TTinstances)
            l3TTinstance.L3STinstanceReferenceId = value;
      }
    }

    public override string FilmReferenceId
    {
      get
      {
        return base.FilmReferenceId;
      }

      set
      {
        base.FilmReferenceId = value; 

        if (L3TTinstances != null)
          foreach (IL3TTinstance l3TTinstance in L3TTinstances)
            l3TTinstance.FilmReferenceId = value;
      }
    }

    public override string ConversationReferenceId
    {
      get
      {
        return base.ConversationReferenceId;
      }

      set
      {
        if (L3TTinstances != null)
          foreach (IL3TTinstance l3TTinstance in L3TTinstances)
            l3TTinstance.ConversationReferenceId = value;

        string oldValue = base.ConversationReferenceId;
        string referenceId = ReferenceId;
        if (referenceId.StartsWith(oldValue + ".")) //if using a structured referenceId (starts with the parent's referenceId, followed by a dot character)...
          ReferenceId = value + referenceId.Remove(0, oldValue.Length); //...update that too

        base.ConversationReferenceId = value;
      }
    }

    public IConversation Conversation
    {
      get
      {
        return Conversation;
      }

      set
      {
        conversation = value;

        //Calculated from Conversation//

        if (value != null)
        {
          ConversationStartTime = value.StartTime;
          ConversationDuration = value.Duration;
          //...
        }
        else
          ClearCalculatedFromConversation(); //don't call ClearCalculated() here, since we also calculate facet values at "L3TTinstances" property

        //Calculated from Film//

        if ((value != null) && (value.Film != null))
        {
          L1language = value.Film.L1language;
          //...
        }
        else
          ClearCalculatedFromFilm(); //don't call ClearCalculated() here, since we also calculate facet values at "L3TTinstances" property
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

          foreach (IL3TTinstance l3TTinstance in value)
            if (l3TTinstance != null)
            {
              l3TTinstance.FilmReferenceId = FilmReferenceId; 
              l3TTinstance.ConversationReferenceId = ConversationReferenceId;
              l3TTinstance.L3STinstanceReferenceId = ReferenceId;

              //...
            }
        }
        else
          ClearCalculatedFromL3TTinstances(); //don't call ClearCalculated() here, since we also calculate facet values at "Conversation" property
      }
    }

    #endregion

  }

}