#define Deque

using System;
using System.Collections.Generic;
using System.Linq;

namespace Sem1402
{
    class Program
    {
        static void Main()
        {
#if Queue
            var t = new MyQueue<int>();
#elif Stack
            var t = new MyStack<int>();
#elif Deque
            var t = new MyDeque<int>();
#else
            object t = null;
#endif
            Test(t);
        }
#if Queue
        static void Test(IMyQueue<int> queue)
        {
            foreach (int i in Enumerable.Range(0, 9))
            {
                queue.Enqueue(i);
            }
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            foreach (int i in Enumerable.Repeat(2, 5))
            {
                queue.Enqueue(i);
            }
            try
            {
                while (true)
                {
                    Console.WriteLine(queue.Dequeue());
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Queue is empty");
            }
        }
#elif Deque
        private static void Test(IMyDeque<int> deque)
        {
            Enumerable.Range(0, 5).ForEach(deque.PushBack);
            Enumerable.Range(5, 5).ForEach(deque.PushFront);
            Console.WriteLine(deque.PeekFront());
            Console.WriteLine(deque.PeekBack());
            try
            {
                while (true)
                {
                    Console.WriteLine(deque.PopBack());
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Deque is Empty");
            }
        }
#elif Stack
        private static void Test(IMyStack<int> stack)
        {
            foreach (var i in Enumerable.Range(0, 9))
            {
                stack.Push(i);
            }
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            foreach (var i in Enumerable.Repeat(2, 5))
            {
                stack.Push(i);
            }

            try
            {
                while (true)
                {
                    Console.WriteLine(stack.Pop());
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Stack is empty");
            }
        }
#else
        static void Test(object t) => throw new NotSupportedException();
#endif
    }

    static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> f)
        {
            foreach (var x1 in enumerable)
            {
                f(x1);
            }
        }
    }
}
