//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Film.cs
//Version: 20160527

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

          L2dubbedLanguages = new string[] { }; //TODO
          L2subtitledLanguages = new string[] { }; //TODO
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}