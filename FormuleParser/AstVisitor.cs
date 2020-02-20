namespace FormuleParser
{
    internal abstract class AstVisitor<T>
    {
        public abstract T Visit(AddNode node);
        public abstract T Visit(SubNode node);
        public abstract T Visit(DivNode node);
        public abstract T Visit(MulNode node);
        public abstract T Visit(PowNode node);
        public abstract T Visit(NegNode node);
        public abstract T Visit(FuncNode node);
        public abstract T Visit(NumberNode node);
        public T Visit(ExprNode node)
        {
            return Visit((dynamic) node);
        }
    }
}