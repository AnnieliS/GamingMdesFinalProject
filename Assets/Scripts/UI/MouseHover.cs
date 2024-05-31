using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameManager.GetInstance().HoverMouseEnter();
    }

    void OnMouseExit()
    {
        GameManager.GetInstance().SetDefaultMouse();
    }
}
