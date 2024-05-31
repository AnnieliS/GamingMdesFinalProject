using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Cursors")]
    [SerializeField] Texture2D cursorTextureDefault;
    [SerializeField] Texture2D cursorTextureHover;
    [SerializeField] Texture2D cursorTextureInspect;
    [SerializeField] CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] Vector2 hotSpot = Vector2.zero;
    private bool canChangeCursors = true;



    private static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Game Manager in the scene");
        }
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        SetDefaultMouse();
    }


    #region Mice
    public void SetDefaultMouse()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTextureDefault, Vector2.zero, cursorMode);

    }

   public void HoverMouseEnter()
    {
        if(canChangeCursors)
        Cursor.SetCursor(cursorTextureHover, hotSpot, cursorMode);
    }

    public void InspectMouseEnter(){
        if(canChangeCursors)
         Cursor.SetCursor(cursorTextureInspect, hotSpot, cursorMode);
    }

    public void HideCursor(){
        if(canChangeCursors)
        Cursor.visible = false;
    }

    public void ShowCursor(){
        if(canChangeCursors)
        Cursor.visible = true;
    }

    public void DisableMouseChange(){
        canChangeCursors = false;
    }

    public void EnableMouseChange(){
        canChangeCursors = true;
    }

    #endregion


}
