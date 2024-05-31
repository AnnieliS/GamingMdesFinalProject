using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSunflower : GAction
{
    PuduAgent pudu;

    private void Start() {
        pudu = GetComponent<PuduAgent>();
    }
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        target.GetComponent<DestroyAfterUse>().DestroyObject();
        pudu.PickSunflower();
       // GWorld.Instance.GetWorld().ModifyState(WorldTags.gworldStates.sunflower.ToString(), -1);
        return true;
    }


}