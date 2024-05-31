using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollRest : GAction
{
    Troll trollAgent;

    private void Start() {
        trollAgent = GetComponent<Troll>();
    }
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        if(GWorld.Instance.GetWorld().states[WorldTags.gworldStates.trollMove.ToString()] == 0) return false;
        return true;
    }
    public override bool PostPerform()
    {
        Debug.Log("post action");
        return true;
    }
}
