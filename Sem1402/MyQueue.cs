using System;

namespace Sem1402
{
    internal class MyQueue<T> : IMyQueue<T>
    {
        private readonly Node<T> _root = new Node<T>();
        private Node<T> _last;
        public int Length { get; private set; }

        public MyQueue()
        {
            _last = _root;
        }

        public void Enqueue(T item)
        {
            _last.Next = new Node<T> { Value = item };
            _last = _last.Next;
            ++Length;
        }

        public T Dequeue()
        {
            if (_root.Next == null)
                throw new InvalidOperationException();
            var t = _root.Next.Value;
            if (_root.Next == _last)
                _last = _root;
            _root.Next = _root.Next.Next;
            --Length;
            return t;
        }

        public T Peek()
        {
            if (_root.Next == null)
                throw new InvalidOperationException();
            return _root.Next.Value;
        }
    }
}