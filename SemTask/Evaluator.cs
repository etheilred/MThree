using System;
using System.Collections.Generic;

namespace SemTask
{
    internal class Evaluator : AstVisitor
    {
        private readonly RootNode _root;

        public Evaluator(RootNode root)
        {
            _root = root;
        }

        public UnifiedValue Visit(RootNode node)
        {
            return Visit(node.Root);
        }

        public UnifiedValue Visit(ListNode node)
        {
            if (node.Head is IdNode)
            {
                if (IdMapping.ListFunctions.ContainsKey(((IdNode)node.Head).Token.Literal))
                {
                    if (ListNode.Length(node.Tail) != 1)
                        throw new ArgumentException($"Too many arguments to {((IdNode)node.Head).Token.Literal}");
                    if (node.Tail.Head is QuotedNode)
                        return IdMapping.ListFunctions[((IdNode)node.Head).Token.Literal]((node.Tail.Head as QuotedNode)?.Quoted as ListNode);
                    if (node.Tail.Head is IdNode)
                    {
                        ListValue lv = (ListValue)Visit(node.Tail);
                        return IdMapping.ListFunctions[((IdNode) node.Head).Token.Literal](lv.List);
                    }
                    else throw new ArgumentException("Could not call a func");
                }
            }
            return Visit(node.Head);
        }

        public UnifiedValue Visit(QuotedNode node)
        {
            if (node.Quoted is ListNode)
                return new ListValue { List = (ListNode)node.Quoted };
            return new AtomValue { Atom = (AtomNode)node.Quoted };
        }

        public UnifiedValue Visit(AtomNode node)
        {
            return new AtomValue { Atom = node };
        }

        public UnifiedValue Visit(dynamic node)
        {
            return Visit(node);
        }
    }

    static class BuiltInFuncs
    {
        public static UnifiedValue Car(ListNode list)
        {
            if (list.Head is ListNode)
                return new ListValue { List = (ListNode)list.Head };
            return new AtomValue { Atom = (AtomNode)list.Head };
        }

        public static UnifiedValue Cdr(ListNode list)
        {
            return new ListValue { List = list.Tail };
        }
    }

    /// <summary>
    /// Maps identifiers with functionality
    /// </summary>
    static class IdMapping
    {
        public static Dictionary<string, Func<ListNode, UnifiedValue>> ListFunctions { get; } =
            new Dictionary<string, Func<ListNode, UnifiedValue>>()
            {
                {"car", BuiltInFuncs.Car},
                {"cdr", BuiltInFuncs.Cdr}
            };
    }
}