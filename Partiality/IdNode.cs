namespace Partiality
{
    /// <summary>
    /// Describes type of identifier node
    /// Always a terminal node
    /// </summary>
    internal class IdNode : AtomNode
    {
        public string Literal { get; set; }

        public override string ToString()
        {
            return $"{Literal}";
        }
    }
}