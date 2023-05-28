using TMPro;
using UnityEngine;

public class Example3 : ExampleCode
{
    [Header("Fields")]
    public TMP_InputField nameInput;
    public TMP_InputField numberInput;

    private string defaultName = "Lanz";
    private int defaultNumber = 22;

    public override void UpdateCode()
    {
        string newCode =
            "<style=keyword>string</style> name;\n" +
           $"name = <style=string>\"{nameInput.text}\"</style>;\n\n" +

            "<style=keyword>int</style> number;\n" +
           $"number = <style=numeric>{numberInput.text}</style>;\n\n" +

            "<style=class>Console</style>.<style=method>WriteLine</style>(name);\n" +
            "<style=class>Console</style>.<style=method>WriteLine</style>(number);";

        codeText.text = newCode;

        UpdateLayout(this);
    }

    public override void RunCode()
    {
        outputText.text = nameInput.text + "\n" + numberInput.text;

        UpdateLayout(this);
    }

    public override void ResetCode()
    {
        nameInput.text = defaultName;
        numberInput.text = defaultNumber.ToString();

        UpdateCode();
    }
}
