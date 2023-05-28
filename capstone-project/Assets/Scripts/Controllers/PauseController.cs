using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject canvas;

    public void OpenCanvas()
    {
        canvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
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
