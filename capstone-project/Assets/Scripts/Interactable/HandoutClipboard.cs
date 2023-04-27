using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandoutClipboard : Interactable
{
    public Canvas canvas;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        canvas.enabled = !canvas.enabled;
        Debug.Log("Interacted with " + gameObject.name);
    }
}
