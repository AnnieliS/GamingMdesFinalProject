using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelDIY : MonoBehaviour
{

    [Header("Next Level")]
    [SerializeField] string teleportSceneName;
    [SerializeField] string teleportToKey;

    private void Start()
    {
        GameManager.GetInstance().ChangeBedroom("DIYFire", true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (teleportToKey != null)
                GameManager.GetInstance().SetNextPortal(teleportToKey);
            else
                GameManager.GetInstance().SetNextPortal("playerInit");
            LevelLoader.GetInstance().LoadLevelByName(teleportSceneName);
            Debug.Log("interact");

        }


    }
}
