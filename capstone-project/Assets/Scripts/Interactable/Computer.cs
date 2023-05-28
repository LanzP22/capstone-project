using UnityEngine;

public class Computer : Interactable
{
    public GameObject canvas;
     
    public override void Interact()
    {
        OpenCanvas();
    }

    public void OpenCanvas()
    {
        canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvas.activeInHierarchy)
        {
            CloseCanvas();
        }
    }
}
