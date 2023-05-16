using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Example1 : ExampleCode
{
    [Header("Fields")]
    public TMP_InputField nameInput;

    private string defaultName = "Lanz";

    public override void UpdateCode()
    {
        string newCode =
           $"<style=keyword>string</style> name = <style=string>\"{nameInput.text}\"</style>;\n" +
            "<style=class>Console</style>.<style=method>WriteLine</style>(name);";

        codeText.text = newCode;

        UpdateLayout(this);
    }

    public override void RunCode()
    {
        outputText.text = nameInput.text;

        UpdateLayout(this);
    }

    public override void ResetCode()
    {
        nameInput.text = defaultName;
        UpdateCode();
    }

    public override void CopyCode()
    {
        GUIUtility.systemCopyBuffer = codeText.text;
    }
}
