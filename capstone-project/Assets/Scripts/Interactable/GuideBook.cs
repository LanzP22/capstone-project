using UnityEngine;

public class GuideBook : Interactable
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

    public void nUpdate()
    {
        if (canvas.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("GuideBook!");
            CloseCanvas();
        }
    }
}
