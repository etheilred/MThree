using System;

namespace AhoCorasick
{
    class Program
    {
        static void Main(string[] args)
        {
            AhoCorasick ac = new AhoCorasick();
            ac.AddString("her");
            ac.AddString("here");
            ac.AddString("herem");
            Console.WriteLine(ac);
        }
    }
}
