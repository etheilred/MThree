using System;

namespace Sem0702
{
    public class Wizard : Creature
    {
        public string Name { get; private set; }

        public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

        public Wizard(string s)
        {
            Name = s;
        }

        public Wizard() { }

        public void SomeThisIsChangedInTheAir()
        {
            Console.WriteLine($"{Name} >> Ring was found at Bilbo's! You are summoned to Rivendell");
            RaiseRingIsFoundEvent?.Invoke(this, new RingIsFoundEventArgs("Rivendell") { NewLoc = "Lonely Mountain"});
        }
    }
}