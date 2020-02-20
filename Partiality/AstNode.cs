namespace Partiality
{
    /// <summary>
    /// Describes base type of all AST nodes
    /// Includes property `AstNode Parent {get;}` for storing node's parent node
    /// </summary>
    internal class AstNode
    {
        public AstNode Parent { get; }

        public AstNode(AstNode parent)
        {
            Parent = parent;
        }

        public AstNode() { }
    }
}