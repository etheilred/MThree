using System;

namespace Sem0702
{
    public class Hobbit : Creature
    {
        public string Name { get; private set; }

        public Hobbit(string s)
        {
            Name = s;
        }

        public void OnRingIsFound(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Leaving Shire! Coming to {e.Message}");
        }
    }
}