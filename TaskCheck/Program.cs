using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = ReadLong();
            Func<long, long>[] func = new Func<long, long>[4];
            func[0] = (long a) =>
            {
                Console.WriteLine($"{a}*{a}={a * a}");
                return a * a;
            };
            func[1] = (long a) =>
            {
                if (a % 3 == 0)
                {
                    Console.WriteLine($"{a}%{3}=0 => 3*{a}={3 * a}");
                    return 3 * a;
                }
                if (a % 3 == 1)
                {
                    Console.WriteLine($"{a}%{3}=1 => 3*{a}={2 * a}");
                    return 2 * a;
                }
                else
                {
                    Console.WriteLine($"{a}%{3}=2 => {a}");
                    return a;
                }
            };
            func[2] = a =>
            {
                Console.WriteLine($"{a * a}-{a}={a * a - a}");
                return a * a - a;
            };
            func[3] = (long a) =>
            {
                if (a % 10 > 5)
                {
                    Console.WriteLine($"{a}%10>5 => {a}»1={a >> 1}");
                    return a >> 1;
                }
                else
                {
                    Console.WriteLine($"{a}%10<=5 => {a}«1={a << 1}");
                    return a << 1;
                }
            };

            foreach (Func<long, long> f in func)
            {
                n = f(n);
            }
            Console.ReadKey();

        }
        static long ReadLong()
        {
            if (!long.TryParse(Console.ReadLine(), out long a))
            {
                Console.WriteLine("Некорректный ввод");
                return ReadLong();
            }
            return a;
        }

    }

}