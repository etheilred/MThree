using System;

namespace Sem1402
{
    internal class MyStack<T> : IMyStack<T>
    {
        public int Length { get; set; }
        private readonly Node<T> _root = new Node<T>();

        public override string ToString() => _root.Next.ToString();

        public void Push(T item)
        {
            ++Length;
            _root.Next = new Node<T> { Value = item, Next = _root.Next };
        }

        public T Pop()
        {
            var toDelete = _root.Next;
            if (toDelete == null)
                throw new InvalidOperationException();
            _root.Next = toDelete.Next;
            --Length;
            return toDelete.Value;
        }

        public T Peek()
        {
            var toPeek = _root.Next;
            if (toPeek == null)
                throw new InvalidOperationException();
            return toPeek.Value;
        }
    }
}