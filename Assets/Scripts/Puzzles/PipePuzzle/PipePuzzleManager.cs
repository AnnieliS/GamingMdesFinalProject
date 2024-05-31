using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzleManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] GameObject puzzleCanvas;

    [SerializeField] float turnOffDelay = 0.2f;
    private GameObject[] puzzleActivating;
    private int totalActivators;

    [Header("Pipes")]
    private GameObject PipesHolder;
    private GameObject[] Pipes;

    [SerializeField]
    int totalPipes = 0;
    [SerializeField]
    int correctedPipes = 0;

    public GameObject WinText;

    CameraControl cameraControl;
    private static PipePuzzleManager instance;
    PuzzleCollider puzzleActivator;
    int attackChanceIncrease;
    int attackChanceDec;
    bool didWin = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Puzzle Manager in the scene");
        }
        instance = this;
    }
    void Start()
    {
    }

    public static PipePuzzleManager GetInstance()
    {
        return instance;
    }

    public void StartPuzzle(GameObject puzzle, PuzzleCollider activator, GameObject[] puzzleActivating)
    {
        GameManager.GetInstance().DisableMouseChange();
        puzzleActivator = activator;
        attackChanceIncrease = activator.playerAttackChanceIncrease;
        this.puzzleActivating = puzzleActivating;
        totalActivators = puzzleActivating.Length;
        attackChanceDec = activator.enemyAttackChanceDecrease;
        for (int i = 0; i < puzzle.transform.childCount; i++)
        {
            if (puzzle.transform.GetChild(i).name == "Pipes")
                PipesHolder = puzzle.transform.GetChild(i).gameObject;
        }
        WinText.SetActive(false);
        totalPipes = PipesHolder.transform.childCount;
        Debug.Log(totalPipes);

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
        CameraControl.GetInstance().TurnOffCameraControl();
        PlayerMovement.GetInstance().StopMovement();
        puzzleCanvas.SetActive(true);
    }

    public void correctMove()
    {
        correctedPipes += 1;

        Debug.Log("correct Move");

        if (correctedPipes == totalPipes)
        {
            Debug.Log("You win!");
            StartCoroutine(ShowMessege());

        }
    }

    public void wrongMove()
    {
        correctedPipes -= 1;
    }

    public void FinishPuzzle()
    {

        StartCoroutine(DelayPuzzleOff());
    }

    private IEnumerator ShowMessege()
    {
        yield return new WaitForSeconds(turnOffDelay);
        didWin = true;
        WinText.SetActive(true);
        GameManager.GetInstance().EnableMouseChange();

    }


    private IEnumerator DelayPuzzleOff()
    {
        yield return new WaitForSeconds(turnOffDelay);
        if (didWin)
        {
            if (totalActivators > 0)
            {
                foreach (GameObject toActivate in puzzleActivating)
                {
                    toActivate.SetActive(true);
                }
            }
            puzzleActivator.isSolved = true;
            puzzleActivator.gameObject.GetComponentInChildren<Animator>().SetBool("finishedPuzzle", true);
        }
        CameraControl.GetInstance().TurnOnCameraControl();
        PlayerMovement.GetInstance().ResumeMovement();

        puzzleCanvas.SetActive(false);
    }
}