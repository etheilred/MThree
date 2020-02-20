namespace Sem1402
{
    internal class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public override string ToString() => $"{Value} {Next}";
    }
}