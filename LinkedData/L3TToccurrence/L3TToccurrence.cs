//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TToccurrence.cs
//Version: 20160525

using Trafilm.Metadata.Models;

namespace Trafilm.Metadata
{

  public class L3TToccurrence : L3TToccurrenceMetadata, IL3TToccurrence
  {

    #region --- Fields ---

    protected IL3SToccurrence l3SToccurrence; //=null

    #endregion

    #region --- Properties ---

    public IL3SToccurrence L3SToccurrence
    {
      get
      {
        return l3SToccurrence;
      }
      set
      {
        l3SToccurrence = value;

        //Calculated from L3SToccurrence//

        if (value != null)
        {
          //TODO: calculate modeChange, functionsChange, ...

          //...
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}