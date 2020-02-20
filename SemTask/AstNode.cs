using System.Collections.Generic;

namespace SemTask
{
    internal abstract class AstNode { }

    internal class RootNode : AstNode
    {
        public AstNode Root { get; set; }
        public override string ToString()
        {
            if (Root is ListNode)
                return $"({Root})";
            return $"{Root}";
        }
    }

    internal class ListNode : AstNode
    {
        public AstNode Head { get; set; }
        public ListNode Tail { get; set; }

        public override string ToString()
        {
            if (Head is ListNode)
                return $"({Head}){(Tail==null?"": " " + Tail)}";
            return $"{Head}{(Tail == null ? "" : " " + Tail)}";
        }

        public static int Length(ListNode list)
        {
            if (list == null)
                return 0;
            return 1 + Length(list.Tail);
        }
    }

    internal class QuotedNode : AstNode
    {
        public AstNode Quoted { get; set; }

        public override string ToString()
        {
            if (Quoted is ListNode)
                return $"'({Quoted})";
            else return $"'{Quoted}";
        }
    }

    internal abstract class AtomNode : AstNode
    {
        public abstract VariableToken Token { get; set; }
    }

    internal class NumNode : AtomNode
    {
        public override VariableToken Token { get; set; }

        public override string ToString()
        {
            return $"{Token.Literal}";
        }
    }

    internal class IdNode : AtomNode
    {
        public override VariableToken Token { get; set; }

        public override string ToString()
        {
            return $"{Token.Literal}";
        }
    }
}