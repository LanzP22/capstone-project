public class PythonCodeProblem : CodeProblem
{
    public PythonCodeProblem(string codeBase, string codeAnswer)
        : base(codeBase, codeAnswer) { }

    public override string Format(string code)
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckAnswer(string answer)
    {
        return true;
    }
}
