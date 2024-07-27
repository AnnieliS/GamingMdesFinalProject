using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Optionals")]
    [SerializeField] private Animator emoteAnimator;
    [SerializeField] private GameObject puzzle = null;
    UnityEvent puzzleCompleteFunction;

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
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) 
        {

            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed()) 
            {
                Debug.Log("interact");
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, emoteAnimator, puzzle);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
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