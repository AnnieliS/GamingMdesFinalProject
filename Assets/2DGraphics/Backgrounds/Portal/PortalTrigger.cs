using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("temp")]
    [SerializeField] GameObject nextLevelPlaceholder;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        nextLevelPlaceholder.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {

            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                LevelLoader.GetInstance().LoadNextLevel();
                Debug.Log("interact");

            }

        }
        else
        {
            nextLevelPlaceholder.SetActive(false);
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
