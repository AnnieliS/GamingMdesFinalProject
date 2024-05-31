using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInishSunflowerRun : GAction
{
    public override bool PrePerform()
    {
//        if(GWorld.Instance.GetWorld().states[WorldTags.gworldStates.sunflowerBox.ToString()] < 50) return false;
        return true;
    }
    public override bool PostPerform()
    {
        return true;
    }

}