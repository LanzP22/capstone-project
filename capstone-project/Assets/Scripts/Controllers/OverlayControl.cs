using System;
using UnityEngine;
using UnityEngine.UI;

public class OverlayControl : MonoBehaviour
{
    private CursorLockMode cursorLockMode;
    public static LeanTweenType easeType = LeanTweenType.easeOutSine;
    public static float delay = 0.3f;

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

    public static void TransitionOpen(GameObject gameOjb)
    {
        TransitionOpen(gameOjb, delegate { });
    }

    public static void TransitionClose(GameObject gameOjb)
    {
        TransitionOpen(gameOjb, delegate { });
    }

    public static void TransitionOpen(GameObject gameOjb, Action onComplete)
    {
        GameObject blurBG = gameOjb.transform.GetChild(0).gameObject;
        GameObject content = blurBG.transform.GetChild(0).gameObject;

        content.transform.localScale = new Vector3(0, 0, 0);

        LeanTween.scale(content, new Vector3(1, 1, 1), delay)
            .setEase(easeType)
            .setOnComplete(onComplete);
    }

    public static void TransitionClose(GameObject gameOjb, Action onComplete)
    {
        GameObject blurBG = gameOjb.transform.GetChild(0).gameObject;
        GameObject content = blurBG.transform.GetChild(0).gameObject;

        LeanTween.scale(content, new Vector3(0, 0, 0), delay)
            .setEase(easeType)
            .setOnComplete(onComplete);
    }
}
