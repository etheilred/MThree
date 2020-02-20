using System;

namespace Delegates
{
    class Program
    {
        delegate int Sum(int x, int y);

        delegate void PrintMessage(string msg);

        delegate Func<int, int> MyInt(int a);

        delegate int IntDel(int k);

        private static event PrintMessage Notify;

        static void Main(string[] args)
        {
            MyInt all = x =>
            {
                return (y) =>
                {
                    ++x;
                    return x+y;
                };
            };
            var fn = all(5);
        }

        static Sum GetSumFunc()
        {
            int z = 0;
            return delegate (int x, int y)
            {
                z++;
                Notify?.Invoke($"Added. Total {z} times");
                return x + y * z;
            };
        }
    }
}
