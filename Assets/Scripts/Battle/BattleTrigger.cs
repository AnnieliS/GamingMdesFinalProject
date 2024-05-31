using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [Header("Character UI Prefab")]
    [SerializeField] GameObject battlePrefab;
    [SerializeField] String animatorNameInResource;
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Emote Animator")]
    [SerializeField] private Animator emoteAnimator;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !BattleDialogueManager.GetInstance().dialogueIsPlaying)
        {

            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                Debug.Log("interact");
                StartBattle();

            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    public void StartBattle()
    {
        PlayerMovement.GetInstance().StopMovement();
        BattleInit.GetInstance().InitiateEnemy(battlePrefab, animatorNameInResource);
        BattleDialogueManager.GetInstance().EnterDialogueMode(inkJSON, emoteAnimator);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("entered trigger");
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
