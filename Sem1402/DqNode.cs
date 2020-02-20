namespace Sem1402
{
    internal class DqNode<T>
    {
        public T Value { get; set; }
        public DqNode<T> Next { get; set; }
        public DqNode<T> Prev { get; set; }
        public override string ToString() => $"{Value} {Next}";
    }
}