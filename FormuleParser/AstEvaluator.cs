using System;

namespace FormuleParser
{
    internal class AstEvaluator : AstVisitor<double>
    {
        public override double Visit(AddNode node)
        {
            return Visit(node.Left) + Visit(node.Right);
        }

        public override double Visit(SubNode node)
        {
            return Visit(node.Left) - Visit(node.Right);
        }

        public override double Visit(DivNode node)
        {
            return Visit(node.Left) / Visit(node.Right);
        }

        public override double Visit(MulNode node)
        {
            return Visit(node.Left) * Visit(node.Right);
        }

        public override double Visit(PowNode node)
        {
            return Math.Pow(Visit(node.Left), Visit(node.Right));
        }

        public override double Visit(NegNode node)
        {
            return -Visit(node.InnerNode);
        }

        public override double Visit(FuncNode node)
        {
            return node.Function(Visit(node.Argument));
        }

        public override double Visit(NumberNode node)
        {
            return node.Value;
        }
    }
}