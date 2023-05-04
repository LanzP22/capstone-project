using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Computer : Interactable
{
    public GameObject canvas;
     
    public override void Interact()
    {
        canvas.SetActive(!canvas.activeInHierarchy);
        Globals.isPlayerFrozen = canvas.activeInHierarchy;

        Debug.Log("Interacted with " + promptMessage);
    }
}
