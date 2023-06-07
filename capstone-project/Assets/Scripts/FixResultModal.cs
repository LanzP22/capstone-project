using UnityEngine;

public class FixResultModal : MonoBehaviour
{
    public GameObject canvas;
    public bool closeParentOnClose = false;

    public void OpenCanvas()
    {
        canvas.SetActive(true);
        OverlayControl.TransitionOpen(canvas);
    }

    public void CloseCanvas()
    {
        OverlayControl.TransitionClose(canvas, () => canvas.SetActive(false));
    }

    public void Close()
    {
        if (closeParentOnClose)
        {
            foreach (GameObject fixableDevice in GameObject.FindGameObjectsWithTag("FixableDevice"))
            {
                fixableDevice.GetComponent<FixableDevice>().CloseCanvas();
            }
        }

        CloseCanvas();
    }
}
