namespace Partiality
{
    /// <summary>
    /// Special type, derived from SExprNode, for describing NIL
    /// </summary>
    internal class NilNode : SExprNode
    {
        public override string ToString()
        {
            return "";
        }
    }
}