using Nobi.UiRoundedCorners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Example1 : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI codeText;
    public TextMeshProUGUI outputText;

    public void Awake()
    {
        UpdateCode();
    }

    public void UpdateCode()
    {
        string newCode =
            $"<color=blue>string</color> name = \"{nameInput.text}\";\n" +
            $"Console.WriteLine(name);";

        codeText.text = newCode;

        UpdateLayout();
    }

    public void RunCode()
    {
        outputText.text = nameInput.text;

        UpdateLayout();
    }

    public void ResetCode()
    {
        nameInput.text = "Lanz";
        UpdateCode();

        UpdateLayout();
    }

    public void CopyCode()
    {
        GUIUtility.systemCopyBuffer = codeText.text;
    }

    void UpdateLayout()
    {
        // Sometimes, dynamically resizing contents of an object by adding new contents such as text
        // triggers a bug that ruins the whole layout of the game object which makes it look weird.
        // This solution fixes that bug by refreshing the RectTransform of the parent game object.

        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());

        // TODO: Fix rounded corners
    }
}
