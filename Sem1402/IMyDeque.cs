namespace Sem1402
{
    internal interface IMyDeque<T>
    {
        void PushBack(T value);
        void PushFront(T value);
        T PopBack();
        T PopFront();
        T PeekFront();
        T PeekBack();
    }
}