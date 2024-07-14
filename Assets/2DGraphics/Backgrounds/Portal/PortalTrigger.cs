using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Next Level")]
    [SerializeField] string teleportSceneName;
    [SerializeField] string teleportToKey;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {

            visualCue.SetActive(true);
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
