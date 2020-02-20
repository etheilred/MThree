using System;

namespace Sem0702
{
    public class Elf : Creature
    {
        public string Name { get; private set; }

        public Elf(string s)
        {
            Name = s;
        }

        public void OnRingIsFound(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Stars are leaves push to go to {e.Message}");
        }
    }
}