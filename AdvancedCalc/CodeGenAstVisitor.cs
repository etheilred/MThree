using System;

namespace AdvancedCalc
{
    class CodeGenAstVisitor : AstVisitor
    {
        private static int Id;

        public override void Visit(AstNode.ExprNode node)
        {
            Visit((dynamic)node);
        }

        public override void Visit(AstNode.BinaryNode node)
        {
            Visit(node.Left);
            Visit(node.Right);
            Console.WriteLine($"L{Id}: t{Id} = t{Id - 2} {node.GetLiteral} t{Id - 1}");
            Id++;
        }

        public override void Visit(AstNode.UnaryNode node)
        {
            Visit((dynamic)node);
        }

        public override void Visit(AstNode.NumNode node)
        {
            Console.WriteLine($"L{Id}: t{Id} = {node.Value}");
            Id++;
        }

        public override void Visit(AstNode.NegNode node)
        {
            Visit(node.InnerNode);
            Console.WriteLine($"L{Id}: t{Id} = {node.GetLiteral}t{Id-1}");
            Id++;
        }
    }
}