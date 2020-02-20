namespace AdvancedCalc
{
    abstract class AstVisitor
    {
        public abstract void Visit(AstNode.ExprNode node);
        public abstract void Visit(AstNode.BinaryNode node);
        public abstract void Visit(AstNode.UnaryNode node);
        public abstract void Visit(AstNode.NumNode node);
        public abstract void Visit(AstNode.NegNode node);

        public void Visit(AstNode node)
        {
            Visit((dynamic)node);
        }
    }
}