using System;
using System.Collections.Generic;

namespace AhoCorasick
{
    internal class KnuthMorrisPratt
    {
        private readonly string _keyword;

        public KnuthMorrisPratt(string keyword)
        {
            _keyword = keyword;
        }

        public int[] FindEntries(string str)
        {
            List<int> entries = new List<int>();

            var f = F(_keyword + "#" + str);
            for (int i = 0; i < f.Length; ++i)
            {
                if (f[i] == _keyword.Length)
                    entries.Add(i - 2*_keyword.Length + 1);
            }

            return entries.ToArray();
        }

        public int[] F(string str)
        {
            Console.WriteLine(str);
            int n = str.Length;
            int[] f = new int[n];

            int t;
            f[0] = 0;

            for (int s = 1; s < n; ++s)
            {
                t = f[s - 1];
                while (t > 0 && str[s] != str[t])
                {
                    t = f[t-1];
                }

                if (str[s] == str[t])
                {
                    ++t;
                }

                f[s] = t;
            }

            return f;
        }
    }
}