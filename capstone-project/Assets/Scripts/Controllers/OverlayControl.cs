using UnityEngine;

public class OverlayControl : MonoBehaviour
{
    private CursorLockMode cursorLockMode;

    void OnEnable()
    {
        cursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;

        GameState.openedCanvas++;
    }

    void OnDisable()
    {
        Cursor.lockState = cursorLockMode;
        GameState.openedCanvas--;
    }
}
