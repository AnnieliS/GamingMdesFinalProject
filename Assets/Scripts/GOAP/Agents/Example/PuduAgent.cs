using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuduAgent : GAgent
{

    private int sunflowerPicked;
    protected override void Start()
    {
        base.Start();
        //Add all actions
        //Subgoal - name of action after effect + what is number? - is nothing
        SubGoal s1 = new SubGoal("PuduRest", 1, true);
        //Action + Priority - higher is earlier
        goals.Add(s1, 3); 
    }

    public void PickSunflower(){
        sunflowerPicked++;
    }

    public void ResetSunflowerCount(){
        sunflowerPicked = 0;
    }

    public int getSunflowerCount(){
        return sunflowerPicked;
    }
}