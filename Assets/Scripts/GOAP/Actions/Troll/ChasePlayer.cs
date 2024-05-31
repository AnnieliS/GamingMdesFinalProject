using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : GAction
{
    Troll trollAgent;

    private void Start()
    {
        trollAgent = GetComponent<Troll>();
    }
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        if (GWorld.Instance.GetWorld().states[WorldTags.gworldStates.trollEnemyinSight.ToString()] > 0)
        {

           
            return true;

        }

        else
            return false;
    }
    public override bool PostPerform()
    {
        Debug.Log("post action");
         trollAgent.ChasePlayer();
        return true;
    }
}
