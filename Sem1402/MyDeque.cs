using System;

namespace Sem1402
{
    internal class MyDeque<T> : IMyDeque<T>, IMyStack<T>, IMyQueue<T>
    {
        private readonly DqNode<T> _left = new DqNode<T>();
        private readonly DqNode<T> _right = new DqNode<T>();
        public int Length { get; set; }

        public MyDeque()
        {
            _left.Next = _right;
            _right.Prev = _left;
        }


        public void PushBack(T value)
        {
            _right.Prev.Next = new DqNode<T>
            {
                Value = value,
                Prev = _right.Prev,
                Next = _right
            };
            _right.Prev = _right.Prev.Next;
            ++Length;
        }

        public void PushFront(T value)
        {
            _left.Next.Prev = new DqNode<T>
            {
                Value = value,
                Next = _left.Next,
                Prev = _left,
            };
            _left.Next = _left.Next.Prev;
            ++Length;
        }

        public T PopBack()
        {
            if (_right.Prev == _left)
                throw new InvalidOperationException();
            --Length;
            var t = _right.Prev.Value;
            _right.Prev = _right.Prev.Prev;
            _right.Prev.Next = _right;
            return t;
        }

        public T PopFront()
        {
            if (_left.Next == _right)
                throw new InvalidOperationException();
            --Length;
            var t = _left.Next.Value;
            _left.Next = _left.Next.Next;
            _left.Next.Prev = _left;
            return t;
        }

        public T PeekFront()
        {
            if (_left.Next == _right)
                throw new InvalidOperationException();
            return _left.Next.Value;
        }

        public T PeekBack()
        {
            if (_right.Prev == _left)
                throw new InvalidOperationException();
            return _right.Prev.Value;
        }

        public override string ToString() => _left.ToString();

        public void Push(T item) => PushBack(item);

        public T Pop() => PopBack();

        public void Enqueue(T item) => PushFront(item);

        public T Dequeue() => PopBack();

        public T Peek() => PeekBack();
    }
}