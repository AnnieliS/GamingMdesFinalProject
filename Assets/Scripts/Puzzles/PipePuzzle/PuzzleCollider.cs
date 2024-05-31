using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;


    [Header("Puzzle")]
    [SerializeField] private GameObject puzzle;
    [SerializeField] public int playerAttackChanceIncrease;
    [SerializeField] public int enemyAttackChanceDecrease;

    [SerializeField] GameObject[] puzzleActivating;
    public bool isSolved = false;
    private Animator visualAnimator;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualAnimator = visualCue.GetComponent<Animator>();
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {

            visualCue.SetActive(true);
            if (isSolved)
                visualAnimator.SetBool("finishedPuzzle", true);
            if (InputManager.GetInstance().GetInteractPressed() && !isSolved)
            {
                Debug.Log("interact");
                PipePuzzleManager.GetInstance().StartPuzzle(puzzle, this, puzzleActivating);
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
