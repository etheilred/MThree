using System;

namespace Sem0702
{
    public class Dwarf : Creature
    {
        public string Name { get; private set; }

        public Dwarf(string s)
        {
            Name = s;
        }

        public void OnRingIsFound(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Rush {e.Message}!!!, I am not in {Location}");
            Location = e.NewLoc;
        }
    }
}