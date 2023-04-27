using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Color hoverColor;

    private TextMeshProUGUI text;
    private Color defaultColor;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        defaultColor = text.color;
    }

    public void PointerEnter()
    {
        text.color = hoverColor;
    }

    public void PointerExit()
    {
        text.color = defaultColor;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
