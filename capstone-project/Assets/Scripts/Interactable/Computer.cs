using UnityEngine;

public class Computer : InteractableObject
{
    public Canvas popupCanvas;

    protected override void Interact()
    {
        popupCanvas.enabled = true;
    }
}
