using System;

namespace FormuleParser
{
    internal abstract class ExprNode
    {
    }

    internal abstract class InfixNode : ExprNode
    {
        public ExprNode Left { get; set; }
        public ExprNode Right { get; set; }
    }

    internal class AddNode : InfixNode
    {
        public override string ToString()
        {
            return "+";
        }
    }

    internal class SubNode : InfixNode
    {
        public override string ToString()
        {
            return "-";
        }
    }

    internal class MulNode : InfixNode
    {
        public override string ToString()
        {
            return "*";
        }
    }

    internal class DivNode : InfixNode
    {
        public override string ToString()
        {
            return "/";
        }
    }

    internal class PowNode : InfixNode
    {
        public override string ToString()
        {
            return "^";
        }
    }

    internal class NegNode : ExprNode
    {
        public ExprNode InnerNode { get; set; }
        public override string ToString()
        {
            return "-";
        }
    }

    internal class NumberNode : ExprNode
    {
        public double Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    internal class FuncNode : ExprNode
    {
        public string FName { get; set; }
        public Func<double, double> Function { get; set; }
        public ExprNode Argument { get; set; }
        public override string ToString()
        {
            return FName;
        }
    }
}
