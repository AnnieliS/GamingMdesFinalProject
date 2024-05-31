using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInspect : MonoBehaviour
{
    void OnMouseEnter()
    {
        GameManager.GetInstance().InspectMouseEnter();
    }

    void OnMouseExit()
    {
        GameManager.GetInstance().SetDefaultMouse();
    }
}
