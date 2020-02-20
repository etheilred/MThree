namespace Sem2401
{
    public class Company
    {
        public int EstablishmentYear { get; }
        public string Name { get; }
        public decimal Capitalization { get; }
        public Person Head { get; }

        public Company(string name, decimal capitalization, int establishmentYear, Person person)
        {
            Name = name;
            Capitalization = capitalization;
            EstablishmentYear = establishmentYear;
            Head = person;
        }

        public override string ToString()
        {
            return $"{Name} ({EstablishmentYear}), Head: [{Head}], Capitalization: {Capitalization}";
        }

        public static Company operator +(Company c1, Company c2)
        {
            return new Company(c1.Name,
                c1.Capitalization + c1.Capitalization,
                c1.EstablishmentYear, 
                c1.Head.NetWorth >= c2.Head.NetWorth ? c1.Head : c2.Head);
        }
    }
}