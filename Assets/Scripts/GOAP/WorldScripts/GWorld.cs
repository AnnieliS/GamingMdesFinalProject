using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld {

    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;

    static GWorld() {
        world = new WorldStates();
        //Add the states of the world, and quantity
        // world.ModifyState(WorldTags.gworldStates.sunflower.ToString(), GameObject.FindGameObjectsWithTag("sunflower").Length);
        world.ModifyState(WorldTags.gworldStates.trollMove.ToString(), 0);
        world.ModifyState(WorldTags.gworldStates.trollEnemyinSight.ToString(), 0);
        world.ModifyState(WorldTags.gworldStates.trollEnterBattle.ToString(), 0);
       

    }

    GWorld() {

    }

    public static GWorld Instance { get { return instance; } }

    public WorldStates GetWorld() => world;
}