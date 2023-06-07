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
        StopPulse();
        canvas.SetActive(true);
        OverlayControl.TransitionOpen(canvas);
    }

    public void CloseCanvas()
    {
        OverlayControl.TransitionClose(canvas, () =>
        {
            canvas.SetActive(false);
            taskHandler.FinishTask();
        });
    }
}
