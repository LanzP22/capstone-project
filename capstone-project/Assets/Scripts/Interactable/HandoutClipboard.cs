using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandoutClipboard : Interactable
{
    public GameObject canvas;

    public override void Interact()
    {
        canvas.SetActive(!canvas.activeInHierarchy);
        Globals.isPlayerFrozen = !canvas.activeInHierarchy;
    }
}
