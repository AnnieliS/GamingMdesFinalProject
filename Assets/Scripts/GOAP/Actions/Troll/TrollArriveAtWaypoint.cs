using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollArriveAtWaypoint : GAction
{
    Troll trollAgent;
    bool wait = true;

    private void Start()
    {
        trollAgent = GetComponent<Troll>();
    }
    // Start is called before the first frame update
    public override bool PrePerform()
    {
        
        // return trollAgent.CanMoveToNextWaypoint();
        StartCoroutine(EndAction());
        return true;
    }

    IEnumerator EndAction(){
        float time = Random.Range(0, 2.5f);
        yield return new WaitForSeconds(time);
    }
    public override bool PostPerform()
    {
        return true;
    }
}
