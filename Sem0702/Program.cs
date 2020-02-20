namespace Sem0702
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Gandalf");
            Hobbit[] hobbits = new Hobbit[4];
            for (var i = 0; i < hobbits.Length; i++)
            {
                hobbits[i] = new Hobbit($"Hobbit_{i}");
                wizard.RaiseRingIsFoundEvent += hobbits[i].OnRingIsFound;
            }

            Human[] humans = { new Human("Boromir"), new Human("Aragorn") };

            Dwarf dwarf = new Dwarf("Gimli");
            Elf elf = new Elf("Legolas");

            wizard.RaiseRingIsFoundEvent += dwarf.OnRingIsFound;
            wizard.RaiseRingIsFoundEvent += elf.OnRingIsFound;

            foreach (var human in humans)
            {
                wizard.RaiseRingIsFoundEvent += human.OnRingIsFound;
            }

            wizard.SomeThisIsChangedInTheAir();
            wizard.SomeThisIsChangedInTheAir();
        }
    }

    public abstract class Creature
    {
        protected string Location = "Not Rivendell";
    }
}
