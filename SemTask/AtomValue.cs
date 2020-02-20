namespace SemTask
{
    internal class AtomValue : UnifiedValue
    {
        public AtomNode Atom { get; set; }

        public AtomValue()
        {
            Type = ValueType.Atomic;
        }

        public override string ToString()
        {
            return Atom.ToString();
        }
    }
}