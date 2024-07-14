using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Cursors")]
    [SerializeField] Texture2D cursorTextureDefault;
    [SerializeField] Texture2D cursorTextureHover;
    [SerializeField] Texture2D cursorTextureInspect;
    [SerializeField] CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] Vector2 hotSpot = Vector2.zero;
    private bool canChangeCursors = true;
    private bool firstTimeEnteringRoom = true;
    //Params
    GlobalParams globalParams;
    string nextPortalTag = "playerInit";



    private static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Found more than one Game Manager in the scene");
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        SetDefaultMouse();
        globalParams = new GlobalParams();
    }

    public void ClickStartInTitle(){
        SceneManager.LoadScene("01_Bedroom");
    }

    #region Mice
    public void SetDefaultMouse()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTextureDefault, Vector2.zero, cursorMode);

    }

    public void HoverMouseEnter()
    {
        if (canChangeCursors)
            Cursor.SetCursor(cursorTextureHover, hotSpot, cursorMode);
    }

    public void InspectMouseEnter()
    {
        if (canChangeCursors)
            Cursor.SetCursor(cursorTextureInspect, hotSpot, cursorMode);
    }

    public void HideCursor()
    {
        if (canChangeCursors)
            Cursor.visible = false;
    }

    public void ShowCursor()
    {
        if (canChangeCursors)
            Cursor.visible = true;
    }

    public void DisableMouseChange()
    {
        canChangeCursors = false;
    }

    public void EnableMouseChange()
    {
        canChangeCursors = true;
    }

    #endregion

    #region global params

    public GlobalParams GetGlobalParams()
    {
        return globalParams;
    }

    public int GetRobiDialogue(string key)
    {
        return globalParams.roomRobiDialogueIndex[key];
    }

    public void SetRobiParams(string key, int value)
    {
        globalParams.roomRobiDialogueIndex[key] = value;
    }

    public void SetNextPortal(string nextPortalKey){
        if(nextPortalKey == null){
            nextPortalTag = "playerInit";
        }

        else{
            nextPortalTag = globalParams.portals[nextPortalKey];
        }
    }

    public string GetNextPortal(){
        return nextPortalTag;
    }

    public void ChangeBedroom(string key, bool newState){
        globalParams.bedRoomParams[key] = newState;
    }

    public bool GetBedroomParams(string key){
        bool value = globalParams.bedRoomParams[key];
        return value;
    }


    
    // public void DebugGlobalParams()
    // {
    //     Debug.Log(globalParams);
    //     Debug.Log("01_Bedroom" + globalParams.roomRobiDialogueIndex["01_Bedroom"]);
    //     Debug.Log("02_OverWorld" + globalParams.roomRobiDialogueIndex["02_OverWorld"]);
    //     Debug.Log("03_Gegloo" + globalParams.roomRobiDialogueIndex["03_Gegloo"]);

    // }

    #endregion



#region get game manager params

public bool IsFirstBedroom(){
    return firstTimeEnteringRoom;
}

public void EnteredBedroom(){
    firstTimeEnteringRoom = false;
}

#endregion

}
