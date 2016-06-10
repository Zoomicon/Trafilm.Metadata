//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Film.cs
//Version: 20160609

using Trafilm.Metadata.Models;

using System.Collections.Generic;
using System.Linq;
using System;

namespace Trafilm.Metadata
{

  public class Film : FilmMetadata, IFilm
  {

    #region --- Fields ---

    protected IEnumerable<IConversation> conversations; //=null

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

        if (Conversations != null)
          foreach (IConversation conversation in Conversations)
            conversation.FilmReferenceId = value;
      }
    }

    public IEnumerable<IConversation> Conversations {
      get
      {
        return conversations;
      }

      set
      {
        conversations = value;

        //Calculated from Conversations//

        if (value != null)
        {
          ConversationCount = value.Count();
          ConversationsDuration = value.Aggregate(TimeSpan.Zero, (total, next) => total.Add(next.Duration ?? TimeSpan.Zero));

          //Calculated from Conversations.L3STinstances.L3TTinstances//

          IList<string> dubbed = new List<string>();
          IList<string> subtitled = new List<string>();
          foreach (IConversation conversation in value)
            if ((conversation != null) && (conversation.L3STinstances != null))

              foreach (IL3STinstance l3STinstance in conversation.L3STinstances)
                if ((l3STinstance != null) && (l3STinstance.L3TTinstances != null))

                  foreach (IL3TTinstance l3TTinstance in l3STinstance.L3TTinstances)
                    if (l3TTinstance != null)
                    {
                      string l2language = l3TTinstance.L2language;
                      if (!string.IsNullOrEmpty(l2language))
                        switch (l3TTinstance.L2mode)
                        {
                          case "Dubbed":
                            if (!dubbed.Contains(l2language))
                              dubbed.Add(l2language);
                            break;
                          case "Subtitled":
                            if (!subtitled.Contains(l2language))
                              subtitled.Add(l2language);
                            break;
                        }
                    }
          L2dubbedLanguages = dubbed.ToArray();
          L2subtitledLanguages = subtitled.ToArray();

          //...
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}