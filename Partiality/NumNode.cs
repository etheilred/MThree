namespace Partiality
{
    /// <summary>
    /// Describes type of Numeric constant nodes.
    /// This is always the terminal node.
    /// </summary>
    internal class NumNode : AtomNode
    {
        public string Literal { get; set; }
        public override string ToString()
        {
            return $"{Literal}";
        }
    }
}