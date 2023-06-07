using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject canvas;

    private bool isTransitioning = false;

    public void OpenCanvas()
    {
        if (isTransitioning)
            return;

        isTransitioning = true;

        canvas.SetActive(true);
        OverlayControl.TransitionOpen(canvas, () => 
        {
            Time.timeScale = 0;
            isTransitioning = false;
        });
    }

    public void CloseCanvas()
    {
        if (isTransitioning)
            return;

        isTransitioning = true;
        Time.timeScale = 1;
        OverlayControl.TransitionClose(canvas, () =>
        {
            canvas.SetActive(false);
            isTransitioning = false;
        });
    }

    public void Resume()
    {
        CloseCanvas();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeInHierarchy)
                CloseCanvas();

            else
                OpenCanvas();
        }
    }
}
