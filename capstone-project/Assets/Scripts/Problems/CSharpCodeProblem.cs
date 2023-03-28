using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class CSharpCodeProblem : CodeProblem
{
    private SyntaxNode _root;

    public CSharpCodeProblem(string codeBase, string codeAnswer)
        : base(codeBase, codeAnswer) 
    {

    }

    public override string Format(string code)
    {
        AdhocWorkspace workspace = new AdhocWorkspace();
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
        SyntaxNode root = BracesRewriter.Rewrite(syntaxTree.GetRoot());

        return Formatter.Format(root, workspace).ToFullString();
    }

    public override bool CheckAnswer(string answer)
    {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(Format(answer));
        SyntaxNode root = tree.GetRoot();

        return SyntaxFactory.AreEquivalent(root, _root);
    }
}

public class BracesRewriter : CSharpSyntaxRewriter
{
    public static SyntaxNode Rewrite(SyntaxNode node)
    {
        return new BracesRewriter().Visit(node);
    }

    public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
    {
        if (node.Statement is BlockSyntax) 
            return base.VisitIfStatement(node);

        BlockSyntax newStatement = SyntaxFactory.Block(node.Statement);
        return node.WithStatement(newStatement);
    }
}