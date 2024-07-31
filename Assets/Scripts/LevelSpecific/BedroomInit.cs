using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomInit : MonoBehaviour
{
    [SerializeField] Transform changeableItemsContainer;
    [SerializeField] GameObject openingCanvas;
    //    Transform[] changeableObjects;
    void Start()
    {
        AudioManager.GetInstance().StartManYell();
        if (GameManager.GetInstance().IsFirstBedroom() == true)
        {
            AudioManager.GetInstance().PauseBGM();
            openingCanvas.SetActive(true);
        }
        else
        {
            openingCanvas.SetActive(false);
            AudioManager.GetInstance().ResumeBGM();
        }
        GameManager.GetInstance().EnteredBedroom();
        // changeableObjects = changeableItemsContainer.GetComponentsInChildren<GameObject>();
        foreach (Transform child in changeableItemsContainer)
        {
            string tag = child.tag;
            child.gameObject.SetActive(GameManager.GetInstance().GetBedroomParams(tag));
        }

    }
    private void OnDestroy()
    {
        AudioManager.GetInstance().StopManYell();
    }


}
