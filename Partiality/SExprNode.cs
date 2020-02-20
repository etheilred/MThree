namespace Partiality
{
    /// <summary>
    /// Describes type of list AST nodes
    /// </summary>
    internal class SExprNode : AstNode
    {
        public AstNode Head { get; set; } = null;
        public AstNode Tail { get; set; } = null;

        public override string ToString()
        {
            string s = "";
            s = !(Head is AtomNode) ? $"({Head})" : $"{Head}";
            if (Tail != null)
                s += $" {Tail}";
            return s;
        }
    }
}