using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void FinishTask()
    {
        text.color = Color.green;
    }
}
