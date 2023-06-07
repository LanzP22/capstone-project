using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void FinishTask()
    {
        if (text.color != Color.green)
        {
            text.color = Color.green;
        }
    }
}
