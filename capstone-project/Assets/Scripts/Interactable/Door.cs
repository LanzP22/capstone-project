using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Door : Interactable
{
    public GameObject tasksContainer;

    public GameObject successModal;
    public GameObject failureModal;

    public override void Interact()
    {
        int totalFinishedTasks = 0;

        foreach (Transform childTransform in tasksContainer.transform) 
        { 
            GameObject childGameObject = childTransform.gameObject;

            if (childGameObject.GetComponent<TextMeshProUGUI>().color == Color.green) 
            { 
                totalFinishedTasks++;
            }
        }

        if (totalFinishedTasks == tasksContainer.transform.childCount)
        {
            OpenCanvas(successModal);
        }
        else
        {
            OpenCanvas(failureModal);
        }
    }

    void OpenCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
        OverlayControl.TransitionOpen(canvas);
    }

    void CloseCanvas(GameObject canvas)
    {
        OverlayControl.TransitionClose(canvas, () => canvas.SetActive(false));
    }

    public void CloseFailureCanvas()
    {
        CloseCanvas(failureModal);
    }
}
