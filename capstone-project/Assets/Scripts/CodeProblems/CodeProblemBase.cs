using System.Collections.Generic;

public abstract class CodeProblem
{
    public string codeBase;
    public string codeAnswer;

    public CodeProblem(string codeBase, string codeAnswer)
    {
        this.codeBase = codeBase;
        this.codeAnswer = codeAnswer;
    }

    public abstract string Format(string code);
    public abstract bool CheckAnswer(string answer);
}

public class CodeProblemGroup
{
    public int id;
    public CSharpCodeProblem cSharpCodeProblem;
    public PythonCodeProblem pythonCodeProblem;
    public JavaCodeProblem javaCodeProblem;
    
    private static Dictionary<int, CodeProblemGroup> _codeProblemGroups = new Dictionary<int, CodeProblemGroup>();

    public static CodeProblemGroup? GetProblem(int id)
    {
        return _codeProblemGroups.GetValueOrDefault(id, null);
    }

    public CodeProblemGroup(int id, CSharpCodeProblem cSharpCodeProblem, PythonCodeProblem pythonCodeProblem, JavaCodeProblem javaCodeProblem)
    {
        this.id = id;
        this.cSharpCodeProblem = cSharpCodeProblem;
        this.pythonCodeProblem = pythonCodeProblem;
        this.javaCodeProblem = javaCodeProblem;

        // _codeProblemGroups.TryAdd(id, this);
        _codeProblemGroups.Add(id, this);
    }
}
