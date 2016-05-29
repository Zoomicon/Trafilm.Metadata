//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TToccurrence.cs
//Version: 20160529

using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

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
          L3STlanguageTypeChange = Diff.GetDifference(value.L3STlanguageType, L3TTlanguageType);
          L3STmodeChange = Diff.GetDifferences(value.L3STmode, L3TTmode);
          L3STfunctionsChange = Diff.GetDifferences(value.L3STfunctions, L3TTfunctions);
          //...
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}