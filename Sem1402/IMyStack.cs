namespace Sem1402
{
    interface IMyStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }
}