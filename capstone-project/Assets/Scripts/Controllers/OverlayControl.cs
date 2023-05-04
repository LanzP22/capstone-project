using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayControl : MonoBehaviour
{
    private CursorLockMode cursorLockMode;

    void OnEnable()
    {
        cursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;
    }

    void OnDisable()
    {
        Cursor.lockState = cursorLockMode;
    }
}
