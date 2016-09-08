//Project: Trafilm.Metadata (https://github.com/Zoomicon/Trafilm.Metadata)
//Filename: L3TTinstance.cs
//Version: 20160908

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

    public override string L3STinstanceReferenceId
    {
      get
      {
        return base.L3STinstanceReferenceId;
      }

      set
      {
        string oldValue = base.L3STinstanceReferenceId;
        string referenceId = ReferenceId;
        if (referenceId.StartsWith(oldValue + ".")) //if using a structured referenceId (starts with the parent's referenceId, followed by a dot character)...
          ReferenceId = value + referenceId.Remove(0, oldValue.Length); //...update that too

        base.L3STinstanceReferenceId = value;
      }
    }

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
          StartTime = value.StartTime;
          Duration = value.Duration;
          L3STlanguageTypeChange = Diff.GetDifferences(value.L3STlanguageType, L3TTlanguageType);
          L3STmodeChange = Diff.GetDifferences(value.L3STmode, L3TTmode);
          L3STfunctionsChange = Diff.GetDifferences(value.L3STfunctions, L3TTfunctions);
          L3STtypesFeaturesChange = Diff.GetDifferences(value.L3STtypesFeatures, L3TTtypesFeatures);
          L3STsourcesChange = Diff.GetDifferences(value.L3STsources, L3TTsources);
          //...
        }
        else
          ClearCalculated();
      }
    }

    #endregion

  }

}