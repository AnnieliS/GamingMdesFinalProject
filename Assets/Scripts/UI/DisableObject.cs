using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
   [SerializeField] GameObject toClose;

   public void DisableObj(){
    toClose.SetActive(false);
   }
}
