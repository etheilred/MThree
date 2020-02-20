using System;

namespace QSort
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {

            int[] a = new int[10000];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(100);
            }
            int[] c = new int[a.Length];
            MergeSort(new ArraySegment<int>(a), new ArraySegment<int>(c));
            Console.WriteLine(IsSorted(c));
        }

        static bool IsSorted<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i - 1].CompareTo(arr[i]) == 1) return false;
            }

            return true;
        }

        static void Merge<T>(ArraySegment<T> a, ArraySegment<T> b, ArraySegment<T> res) where T : IComparable
        {
            if (a.Array == null || b.Array == null || res.Array == null)
                throw new ArgumentException();
            int i = a.Offset, j = b.Offset, r = res.Offset;
            while (i + j - a.Offset - b.Offset < res.Count)
            {
                if (i < a.Count + a.Offset && j < b.Count + b.Offset && a.Array[i].CompareTo(b.Array[j]) != 1)
                {
                    while (i < a.Count + a.Offset && a.Array[i].CompareTo(b.Array[j]) != 1)
                    {
                        res.Array[r + i + j - a.Offset - b.Offset] = a.Array[i];
                        ++i;
                    }
                }
                else if (i < a.Count + a.Offset && j < b.Count + b.Offset)
                {
                    while (j < b.Count + b.Offset && b.Array[j].CompareTo(a.Array[i]) != 1)
                    {
                        res.Array[r + i + j - a.Offset - b.Offset] = b.Array[j];
                        ++j;
                    }
                }
                if (i >= a.Count + a.Offset)
                    while (j < b.Count + b.Offset)
                    {
                        res.Array[r + i + j - a.Offset - b.Offset] = b.Array[j];
                        ++j;
                    }
                else if (j >= b.Count + b.Offset)
                    while (i < a.Count + a.Offset)
                    {
                        res.Array[r + i + j - a.Offset - b.Offset] = a.Array[i];
                        ++i;
                    }
            }
        }

        static void MergeSort<T>(ArraySegment<T> array, ArraySegment<T> sorted) where T : IComparable
        {
            if (array.Count == 0)
                return;
            if (array.Count == 1)
            {
                sorted.Array[sorted.Offset] = array.Array[array.Offset];
                return;
            }
            ArraySegment<T> a = new ArraySegment<T>(array.Array, array.Offset, array.Count / 2);
            ArraySegment<T> b = new ArraySegment<T>(
                array.Array, array.Offset + array.Count / 2, array.Count - array.Count / 2);
            ArraySegment<T> sorted_a = new ArraySegment<T>(sorted.Array, sorted.Offset, sorted.Count / 2);
            ArraySegment<T> sorted_b = new ArraySegment<T>(
                sorted.Array, sorted.Offset + sorted.Count / 2, sorted.Count - sorted.Count / 2);
            MergeSort<T>(a, sorted_a);
            MergeSort<T>(b, sorted_b);
            Array.Copy(sorted_a.Array, sorted_a.Offset, a.Array, a.Offset, sorted_a.Count);
            Array.Copy(sorted_b.Array, sorted_b.Offset, b.Array, b.Offset, sorted_b.Count);
            Merge(a, b, sorted);
        }
    }
}
