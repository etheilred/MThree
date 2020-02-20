using System;
using System.Collections.Generic;

namespace AdvancedCalc
{
    public abstract class AstNode
    {
        public class ExprNode : AstNode
        {
            public virtual string GetLiteral => "";
        }

        public class BinaryNode : ExprNode
        {
            public ExprNode Left { get; set; }
            public ExprNode Right { get; set; }
        }

        public class UnaryNode : ExprNode
        {
            public ExprNode InnerNode { get; set; }
        }

        public class NegNode : UnaryNode
        {
            public override string GetLiteral => "-";
            public override string ToString()
            {
                return $"(- {InnerNode})";
            }
        }

        public class AddNode : BinaryNode
        {
            public override string GetLiteral => "+";
            public override string ToString()
            {
                return $"(+ {Left} {Right})";
            }
        }

        public class SubNode : BinaryNode
        {
            public override string GetLiteral => "-";
            public override string ToString()
            {
                return $"(- {Left} {Right})";
            }
        }


        public class MulNode : BinaryNode
        {
            public override string GetLiteral => "*";
            public override string ToString()
            {
                return $"(* {Left} {Right})";
            }
        }

        public class DivNode : BinaryNode
        {
            public override string GetLiteral => "/";
            public override string ToString()
            {
                return $"(/ {Left} {Right})";
            }
        }

        public class PowNode : BinaryNode
        {
            public override string GetLiteral => "^";
            public override string ToString()
            {
                return $"(^ {Left} {Right})";
            }
        }

        public class NeNode : BinaryNode
        {
            public override string GetLiteral => "!=";
            public override string ToString()
            {
                return $"(!= {Left} {Right})";
            }
        }
        public class GrNode : BinaryNode
        {
            public override string GetLiteral => ">";
            public override string ToString()
            {
                return $"(> {Left} {Right})";
            }
        }
        public class LsNode : BinaryNode
        {
            public override string GetLiteral => "<";
            public override string ToString()
            {
                return $"(< {Left} {Right})";
            }
        }

        public class LeNode : BinaryNode
        {
            public override string GetLiteral => "<=";
            public override string ToString()
            {
                return $"(<= {Left} {Right})";
            }
        }

        public class GeNode : BinaryNode
        {
            public override string GetLiteral => ">=";
            public override string ToString()
            {
                return $"(>= {Left} {Right})";
            }
        }

        public class EqNode : BinaryNode
        {
            public override string GetLiteral => "=";
            public override string ToString()
            {
                return $"(= {Left} {Right})";
            }
        }

        public class FuncArgs : ExprNode
        {
            public override string GetLiteral => ", ";
            public List<ExprNode> Argumets { get; } = new List<ExprNode>();

            public override string ToString()
            {
                return String.Join(" ", Argumets);
            }
        }

        public class FuncNode : ExprNode
        {
            public override string GetLiteral => FuncName;
            public string FuncName { get; set; }
            public FuncArgs Arguments { get; set; }
            public override string ToString()
            {
                return $"({FuncName} {Arguments})";
            }
        }

        public class NumNode : ExprNode
        {
            public double Value { get; set; }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}