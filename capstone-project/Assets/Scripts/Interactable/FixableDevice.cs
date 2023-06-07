using UnityEngine;

public class FixableDevice : Interactable
{
    public GameObject canvas;
    public GameObject successOverlay;
    public GameObject failOverlay;
    public TaskHandler taskHandler;
     
    public override void Interact()
    {
        OpenCanvas();
    }

    public void OpenCanvas()
    {
        canvas.SetActive(true);
        OverlayControl.TransitionOpen(canvas);
    }

    public void CloseCanvas()
    {
        OverlayControl.TransitionClose(canvas, () => canvas.SetActive(false));
    }

    public void CheckAnswers()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NodeSlot");

        foreach (GameObject nodeSlot in gameObjects)
        {
            if (!nodeSlot.GetComponent<NodeSlot>().CheckAnswer())
            {
                failOverlay.GetComponent<FixResultModal>().OpenCanvas();
                break;
            }

            StopPulse();
            interactable = false;
            taskHandler.FinishTask();

            successOverlay.GetComponent<FixResultModal>().OpenCanvas();
        }
    }
}
