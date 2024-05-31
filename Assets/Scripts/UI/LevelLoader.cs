using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float animationTime;
    [Header("Level Attributes")]
    [SerializeField] AudioClip levelBGM;
    [Header("Parameters")]
    [SerializeField] bool enterAnimation;
    [SerializeField] bool playableLevel = false;
    [SerializeField] string playerInitTransformTag = "playerInit";

    GameObject loadCanvas;

    private static LevelLoader instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one LevelLoader in the scene");
        }
        instance = this;
    }

     public static LevelLoader GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        loadCanvas = this.gameObject.transform.GetChild(0).gameObject;
        loadCanvas.SetActive(enterAnimation);
        InitilizeLevel();
    }

    private void InitilizeLevel()
    {
        if (playableLevel)
        {
            PlayerMovement.GetInstance().gameObject.transform.position = GameObject.FindGameObjectWithTag(playerInitTransformTag).transform.position;
        }
        GameManager.GetInstance().SetDefaultMouse();
        StartCoroutine(LoadSound());
    }

    IEnumerator LoadSound(){
        yield return new WaitForSeconds(0.2f);
        if (levelBGM != null)
        {
            Debug.Log(AudioManager.GetInstance().name);
            Debug.Log(AudioManager.GetInstance());
            AudioManager.GetInstance().SwitchBGM(levelBGM);
        }

    }

   

    public void LoadNextLevel()
    {
        GameManager.GetInstance().HideCursor();
        loadCanvas.SetActive(true);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(animationTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void BackToRoom()
    {
        MenuManager.GetInstance().HideQuitConfirmation();
        MenuManager.GetInstance().HideMainMenu();
        StartCoroutine(LoadBedroom());
    }

    IEnumerator LoadBedroom()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(animationTime);
        SceneManager.LoadScene("Bedroom");
    }
}
