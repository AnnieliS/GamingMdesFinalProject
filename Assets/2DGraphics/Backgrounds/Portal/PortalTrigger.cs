using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject[] visualCue;

    [Header("Next Level")]
    [SerializeField] string teleportSceneName;
    [SerializeField] string teleportToKey;
    Outline outline;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        foreach (GameObject cue in visualCue)
        {
            cue.SetActive(false);
        }
    }

    private void Start()
    {
        outline = GetComponentInChildren<Outline>();
        if (outline != null)
            outline.enabled = false;
    }

    private void Update()
    {
        if (playerInRange)
        {

            foreach (GameObject cue in visualCue)
            { cue.SetActive(true); }
            if (outline != null)
            {
                outline.enabled = true;
            }
            if (InputManager.GetInstance().GetInteractPressed())
            {
                if (teleportToKey != null)
                    GameManager.GetInstance().SetNextPortal(teleportToKey);
                else
                    GameManager.GetInstance().SetNextPortal("playerInit");
                LevelLoader.GetInstance().LoadLevelByName(teleportSceneName);
                Debug.Log("interact");

            }

        }
        else
        {
            foreach (GameObject cue in visualCue) { cue.SetActive(false); }
            if (outline != null)
                outline.enabled = false;

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
