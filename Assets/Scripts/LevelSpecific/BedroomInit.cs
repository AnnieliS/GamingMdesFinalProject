using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomInit : MonoBehaviour
{
   [SerializeField] Transform changeableItemsContainer;
//    Transform[] changeableObjects;
    void Start()
    {
        // changeableObjects = changeableItemsContainer.GetComponentsInChildren<GameObject>();
        foreach (Transform child in changeableItemsContainer){
            string tag = child.tag;
            child.gameObject.SetActive(GameManager.GetInstance().GetBedroomParams(tag));
        }
        
    }

}
