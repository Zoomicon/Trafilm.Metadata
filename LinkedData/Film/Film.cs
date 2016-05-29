//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Film.cs
//Version: 20160529

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

          //Calculated from Conversations.L3SToccurrences.L3TToccurrences//

          IList<string> dubbed = new List<string>();
          IList<string> subtitled = new List<string>();
          foreach (Conversation conversation in value)
            if ((conversation != null) && (conversation.L3SToccurrences != null))
              foreach (L3SToccurrence l3SToccurrence in conversation.L3SToccurrences)
                if ((l3SToccurrence != null) && (l3SToccurrence.L3TToccurrences != null))
                  foreach (L3TToccurrence l3TToccurrence in l3SToccurrence.L3TToccurrences)
                    if (l3TToccurrence != null)
                    {
                      string l2language = l3TToccurrence.L2language;
                      if (!string.IsNullOrEmpty(l2language))
                        switch (l3TToccurrence.L2mode)
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