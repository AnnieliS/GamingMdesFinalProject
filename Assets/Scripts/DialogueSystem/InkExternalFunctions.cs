using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story, Animator emoteAnimator, GameObject puzzle = null )
    {
        story.BindExternalFunction("playEmote", (string emoteName) => PlayEmote(emoteName, emoteAnimator));
        story.BindExternalFunction("showRobiButton", () => ShowRobiButton());
        story.BindExternalFunction("robiSpeak", (string line) => RobiSpeak(line));
        story.BindExternalFunction("pauseBGM",() => PauseBGM());
        story.BindExternalFunction("resumeBGM", () => ResumeBGM());
        // story.BindExternalFunction("killPlayer" ,() =>  KillPlayer());
        story.BindExternalFunction("changeEnemyAnim", (string enemy, int anim) => ChangeEnemyAnimation(enemy, anim));
        story.BindExternalFunction("enterPuzzle", (string key) => EnterPuzzle(puzzle, key));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("playEmote");
        story.UnbindExternalFunction("robiSpeak");
        story.UnbindExternalFunction("showRobiButton");
        story.UnbindExternalFunction("pauseBGM");
        // story.UnbindExternalFunction("changeAttackChance");
        // story.UnbindExternalFunction("changeEnemyAttackChance");
        story.UnbindExternalFunction("changeEnemyAnim");
    }

    public void PlayEmote(string emoteName, Animator emoteAnimator)
    {
        if (emoteAnimator != null)
        {
            emoteAnimator.SetTrigger(emoteName);
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

    public void ShowRobiButton(){
        RobiDialogue.GetInstance().ShowRobiButton();
    }

    public void RobiSpeak(string line){
        AudioManager.GetInstance().PlayRobiLine(line);
    }

    public void PauseBGM(){
        AudioManager.GetInstance().PauseBGM();
    }
    public void ResumeBGM(){
        AudioManager.GetInstance().ResumeBGM();
    }

    public void EnterPuzzle(GameObject puzzle, string key = ""){
                PipePuzzleManager.GetInstance().StartPuzzle(puzzle, bedroomParamKey: key);
    }

}