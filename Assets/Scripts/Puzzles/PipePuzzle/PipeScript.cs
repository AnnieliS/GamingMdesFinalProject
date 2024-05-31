using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0f, 90f, 180f, 270f };

    public float[] correctRotation;
    [SerializeField] bool isPlaced = false;

    int PossibleRots = 1;

    PipePuzzleManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("PuzzlesManager").GetComponent<PipePuzzleManager>();

    }

    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        Debug.Log("rotation: " + rand);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Floor(rotations[rand]));

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
    }

    public void ClickPiece()
    {
        transform.Rotate(new Vector3(0f, 0f, 90f));

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && !isPlaced)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        else
        {
           
            if (Mathf.Floor(transform.eulerAngles.z) == correctRotation[0] && !isPlaced)
            {
                Debug.Log("piece of shit");
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
       
    }
}
