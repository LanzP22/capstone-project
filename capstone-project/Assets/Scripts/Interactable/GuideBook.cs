using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBook : Interactable
{
    public GameObject canvas;

    public override void Interact()
    {
        canvas.SetActive(true);
        Globals.isPlayerFrozen = true;
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
        Globals.isPlayerFrozen = false;
    }

    public void Update()
    {
        if (canvas.activeInHierarchy && Input.GetKey(KeyCode.Escape)) 
        {
            CloseCanvas();
        }
    }
}
