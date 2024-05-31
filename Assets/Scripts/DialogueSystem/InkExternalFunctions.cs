using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story, Animator emoteAnimator)
    {
        // story.BindExternalFunction("playEmote", (string emoteName) => PlayEmote(emoteName, emoteAnimator));
        story.BindExternalFunction("killPlayer" ,() =>  KillPlayer());
        story.BindExternalFunction("changeEnemyAnim", (string enemy, int anim) => ChangeEnemyAnimation(enemy, anim));
    }

    public void Unbind(Story story)
    {
        // story.UnbindExternalFunction("playEmote");
        // story.UnbindExternalFunction("changeAttackChance");
        // story.UnbindExternalFunction("changeEnemyAttackChance");
        story.UnbindExternalFunction("changeEnemyAnim");
    }

    public void PlayEmote(string emoteName, Animator emoteAnimator)
    {
        if (emoteAnimator != null)
        {
            emoteAnimator.Play(emoteName);
        }
        else
        {
            Debug.LogWarning("Tried to play emote, but emote animator was "
                + "not initialized when entering dialogue mode.");
        }
    }
    public void KillPlayer(){
        PlayerMovement.GetInstance().PlayerDie();
    }

/// anim 1 - attack        anim 2 - damage      anim 3 - death
    public void ChangeEnemyAnimation(string enemy, int anim){
        GameObject tempObject = GameObject.FindGameObjectWithTag("enemyBattleObj");
        Debug.Log("change anim temp obj "+ tempObject.name);
        if(tempObject == null) return;
       tempObject.GetComponent<EnemyBehaviour>().SelectAnimation(anim);

    }

}