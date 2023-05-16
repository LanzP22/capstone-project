using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public abstract class ExampleCode : MonoBehaviour
{
    [Header("GUI")]
    public TextMeshProUGUI codeText;
    public TextMeshProUGUI outputText;

    [Header("Action Buttons")]
    public Button runButton;
    public Button resetButton;
    public Button copyButton;


    private void Awake()
    {
        // Add button onClick listeners
        runButton.onClick.AddListener(RunCode);
        resetButton.onClick.AddListener(ResetCode);
        copyButton.onClick.AddListener(CopyCode);

        ResetCode();
        RunCode();
    }

    public abstract void UpdateCode();
    public abstract void RunCode();
    public abstract void ResetCode();
    public abstract void CopyCode();

    public void UpdateLayout(Component component)
    {
        // Sometimes, dynamically resizing contents of an object by adding new contents such as text
        // triggers a bug that ruins the whole layout of the game object which makes it look weird.
        // This solution fixes that bug by refreshing the RectTransform of the parent game object.

        LayoutRebuilder.ForceRebuildLayoutImmediate(component.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(component.GetComponent<RectTransform>());

        // TODO: Fix rounded corners
    }

}
