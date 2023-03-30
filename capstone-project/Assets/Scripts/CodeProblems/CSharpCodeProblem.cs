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
        SyntaxTree tree = CSharpSyntaxTree.ParseText(Format(codeAnswer));
        _root = tree.GetRoot();
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

class BracesRewriter : CSharpSyntaxRewriter
{
    public static SyntaxNode Rewrite(SyntaxNode node)
    {
        return new BracesRewriter().Visit(node);
    }

    // If Statement
    public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
    {
        if (node.Statement is BlockSyntax) 
            return base.VisitIfStatement(node);

        BlockSyntax newStatement = SyntaxFactory.Block(node.Statement);
        return node.WithStatement(newStatement);
    }

    // For Statement
    public override SyntaxNode VisitForStatement(ForStatementSyntax node)
    {
        if (node.Statement is BlockSyntax) 
            return base.VisitForStatement(node);

        BlockSyntax newStatement = SyntaxFactory.Block(node.Statement);
        return node.WithStatement(newStatement);
    }

    // ForEach Statement
    public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
    {
        if (node.Statement is BlockSyntax) 
            return base.VisitForEachStatement(node);

        BlockSyntax newStatement = SyntaxFactory.Block(node.Statement);
        return node.WithStatement(newStatement);
    }

    // While Statement
    public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
    {
        if (node.Statement is BlockSyntax) 
            return base.VisitWhileStatement(node);

        BlockSyntax newStatement = SyntaxFactory.Block(node.Statement);
        return node.WithStatement(newStatement);
    }

    // Do-While Statement
    public override SyntaxNode VisitDoStatement(DoStatementSyntax node)
    {
        if (node.Statement is BlockSyntax) 
            return base.VisitDoStatement(node);

        BlockSyntax newStatement = SyntaxFactory.Block(node.Statement);
        return node.WithStatement(newStatement);
    }
}