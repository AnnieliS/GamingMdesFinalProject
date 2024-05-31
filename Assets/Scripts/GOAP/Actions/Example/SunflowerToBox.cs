using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerToBox : GAction
{
    PuduAgent pudu;

    private void Start() {
        pudu = GetComponent<PuduAgent>();
    }
    public override bool PrePerform()
    {
        if(pudu.getSunflowerCount() >= 5){
            return true;
        }
        else return false;
    }

    public override bool PostPerform()
    {
        pudu.ResetSunflowerCount();
     //   GWorld.Instance.GetWorld().ModifyState(WorldTags.gworldStates.sunflowerBox.ToString(), +1);
        return true;
        
    }
}