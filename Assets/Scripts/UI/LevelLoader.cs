using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float animationTime;
    [Header("Level Attributes")]
    [SerializeField] AudioClip[] levelBGM;
    [SerializeField] bool startWithBGM = true;
    [Header("Robi's Canvas")]
    [SerializeField] GameObject robiCanvasLevelEnd;
    [SerializeField] GameObject robiCanvasLevelStart;
    [Header("Parameters")]
    [SerializeField] bool enterAnimation;
    [SerializeField] bool playableLevel = false;
    [SerializeField] bool hasRobi = false;
    [SerializeField] GameObject toTurnOff;
    string playerInitTransformTag = "playerInit";

    AsyncOperation asyncOperation;

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
        if (hasRobi)
        {
            StartCoroutine(RobiLevelStart());
        }
    }

    private void InitilizeLevel()
    {
        if (playableLevel)
        {
            playerInitTransformTag = GameManager.GetInstance().GetNextPortal();
            PlayerMovement.GetInstance().gameObject.transform.position = GameObject.FindGameObjectWithTag(playerInitTransformTag).transform.position;
        }
        GameManager.GetInstance().SetDefaultMouse();
        StartCoroutine(LoadSound());
    }

    IEnumerator LoadSound()
    {
        yield return new WaitForSeconds(0.2f);
        if (levelBGM != null)
        {
            Debug.Log(AudioManager.GetInstance().name);
            Debug.Log(AudioManager.GetInstance());
            if (levelBGM.Length == 1)
                AudioManager.GetInstance().SwitchBGM(levelBGM[0]);
                if(startWithBGM)
                AudioManager.GetInstance().ResumeBGM();
            else
            {
                int rand = Random.Range(0, levelBGM.Length);
                AudioManager.GetInstance().SwitchBGM(levelBGM[rand]);
                if(startWithBGM)
                AudioManager.GetInstance().ResumeBGM();

            }
        }

    }

    IEnumerator RobiLevelStart()
    {
        yield return new WaitForSeconds(animationTime);
        if (robiCanvasLevelStart != null)
        {
            robiCanvasLevelStart.SetActive(true);
        }
    }


    // no robi next level
    public void LoadNextLevel()
    {
        GameManager.GetInstance().HideCursor();
        loadCanvas.SetActive(true);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, null));
    }

    public void LoadLevelByName(string nextSceneName)
    {
        Debug.Log(nextSceneName);
        GameManager.GetInstance().HideCursor();
        loadCanvas.SetActive(true);
        // int nextLevelIndex = SceneManager.GetSceneByPath(nextSceneName).buildIndex;
        // Debug.Log(nextLevelIndex);
        StartCoroutine(LoadLevel(-1, nextSceneName));
    }

    //Robi at the end of the level
    public void LoadGame()
    {
        GameManager.GetInstance().SetDefaultMouse();
        // GameManager.GetInstance().HideCursor();
        // asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadYourAsyncScene("02_OverWorld"));
        GameManager.GetInstance().SetNextPortal("playerInit");
        robiCanvasLevelEnd.SetActive(true);
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void PressRobiButton()
    {
        StartCoroutine(StartLevel());

    }

    IEnumerator StartLevel()
    {
        GameManager.GetInstance().HideCursor();
        loadCanvas.SetActive(true);
        transition.SetTrigger("start");
        yield return new WaitForSeconds(animationTime);
        asyncOperation.allowSceneActivation = true;
    }

    IEnumerator LoadLevel(int levelIndex, string nextSceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(animationTime);
        if (levelIndex == -1)
            SceneManager.LoadScene(nextSceneName);
        else
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
        SceneManager.LoadScene("01_Bedroom");
    }

    public void TurnOffGameObject(){
        toTurnOff.SetActive(false);
    }
}
