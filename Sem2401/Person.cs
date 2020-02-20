using System;

namespace Sem2401
{
    public class Person : IComparable, IComparable<Person>
    {
        public string Name { get; }
        public decimal NetWorth { get; }

        public Person(string name, decimal worth)
        {
            Name = name;
            NetWorth = worth;
        }

        public int CompareTo(Person other)
        {
            return NetWorth.CompareTo(other.NetWorth);
        }

        public override string ToString()
        {
            return $"{Name}, ${NetWorth}";
        }

        public int CompareTo(object obj)
        {
            return NetWorth.CompareTo((obj as Person)?.NetWorth);
        }

        public static bool operator >(Person person1, Person person2)
        {
            return person1.CompareTo(person2) != -1;
        }

        public static bool operator <(Person person1, Person person2)
        {
            return person1.CompareTo(person2) != 1;
        }
    }
}