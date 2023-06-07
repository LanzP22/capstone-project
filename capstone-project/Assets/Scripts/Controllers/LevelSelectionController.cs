using UnityEngine;

public class LevelSelectionController : MonoBehaviour
{
    public GameObject languageSelectionCanvas;

    public GameObject csLevelSelectionCanvas;
    public GameObject javaLevelSelectionCanvas;
    public GameObject pythonLevelSelectionCanvas;

    public void OpenLanguageSelection()
    {
        languageSelectionCanvas.SetActive(true);
        OverlayControl.TransitionOpen(languageSelectionCanvas);
    }

    public void CloseLanguageSelection()
    {
        OverlayControl.TransitionClose(languageSelectionCanvas, () => languageSelectionCanvas.SetActive(false));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenCSLevelSelection()
    {
        csLevelSelectionCanvas.SetActive(true);
        OverlayControl.TransitionOpen(csLevelSelectionCanvas);
    }

    public void OpenJavaLevelSelection()
    {
        javaLevelSelectionCanvas.SetActive(true);
        OverlayControl.TransitionOpen(javaLevelSelectionCanvas);
    }

    public void OpenPythonLevelSelection()
    {
        pythonLevelSelectionCanvas.SetActive(true);
        OverlayControl.TransitionOpen(pythonLevelSelectionCanvas);
    }
}
