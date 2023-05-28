using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class InitTaskList : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
