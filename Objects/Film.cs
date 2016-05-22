//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: Film.cs
//Version: 20160522

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
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}