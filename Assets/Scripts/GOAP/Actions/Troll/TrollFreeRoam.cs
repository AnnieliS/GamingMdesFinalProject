using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollFreeRoam : GAction
{
    Troll trollAgent;

    private void Start() {
        trollAgent = GetComponent<Troll>();
    }
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        // Debug.Log("pre action");
        trollAgent.SetNewWaypoint();
        return true;
    }
    public override bool PostPerform()
    {
        Debug.Log("post action");
        return true;
    }
}