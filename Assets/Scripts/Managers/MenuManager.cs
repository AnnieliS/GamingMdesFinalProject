using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainManuCanvas;

    [SerializeField] GameObject areYouSureCanvas;

    private static MenuManager instance;

    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Menu Manager in the scene");
        }
        instance = this;
    }
    void Start()
    {
    }

    public static MenuManager GetInstance()
    {
        return instance;
    }


    public void HideMainMenu()
    {
        Time.timeScale = 1;
        mainManuCanvas.SetActive(false);
        areYouSureCanvas.SetActive(false);

    }

    public void ShowQuitConfirmation()
    {
        areYouSureCanvas.SetActive(true);
    }

    public void HideQuitConfirmation()
    {
        areYouSureCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
