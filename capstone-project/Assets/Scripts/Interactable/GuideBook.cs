using UnityEngine;

public class GuideBook : Interactable
{
    public GameObject canvas;
    public TaskHandler taskHandler;

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
        taskHandler.FinishTask();
    }
}
