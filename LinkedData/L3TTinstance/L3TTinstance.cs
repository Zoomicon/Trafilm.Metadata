//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TTinstance.cs
//Version: 20160530

using Trafilm.Metadata.Models;
using Trafilm.Metadata.Utils;

namespace Trafilm.Metadata
{

  public class L3TTinstance : L3TTinstanceMetadata, IL3TTinstance
  {

    #region --- Fields ---

    protected IL3STinstance l3STinstance; //=null

    #endregion

    #region --- Properties ---

    public IL3STinstance L3STinstance
    {
      get
      {
        return l3STinstance;
      }
      set
      {
        l3STinstance = value;

        //Calculated from L3STinstance//

        if (value != null)
        {
          L3STlanguageTypeChange = Diff.GetDifferences(value.L3STlanguageType, L3TTlanguageType);
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