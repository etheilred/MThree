using System;

namespace Sem0702
{
    public class Human : Creature
    {
        public string Name { get; private set; }

        public Human(string s)
        {
            Name = s;
        }

        public void OnRingIsFound(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Wisard {((Wizard)sender).Name} has summoned. I am aimed at {e.Message}");
        }
    }
}