namespace Sem1402
{
    interface IMyQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}