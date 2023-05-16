using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Example2 : ExampleCode
{
    [Header("Fields")]
    public TMP_InputField numberInput;

    private int defaultNumber = 22;

    public override void UpdateCode()
    {
        string newCode =
           $"<style=keyword>int</style> number = <style=numeric>{numberInput.text}</style>;\n" +
            "<style=class>Console</style>.<style=method>WriteLine</style>(number);";

        codeText.text = newCode;

        UpdateLayout(this);
    }

    public override void RunCode()
    {
        outputText.text =  numberInput.text;

        UpdateLayout(this);
    }

    public override void ResetCode()
    {
        numberInput.text = defaultNumber.ToString();

        UpdateCode();
    }

    public override void CopyCode()
    {
        GUIUtility.systemCopyBuffer = codeText.text;
    }
}
