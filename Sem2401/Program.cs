using System;
using System.Linq;

namespace Sem2401
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("YOY", 123m);
            Person p2 = new Person("GG", 661);
            Person p3 = new Person("dfdf", 9944);
            Person p4 = new Person("Jack", 1000);
            Person[] persons = new Person[] { person, p2, p3, p4 };
            Array.Sort(persons,
                (x, y) => x.NetWorth > y.NetWorth ? -1 : x.NetWorth < y.NetWorth ? 1 : 0);

            foreach (var person1 in persons)
            {
                Console.WriteLine(person1);
            }

            Company ArmaggedonsBlade = new Company("HSE", 100, 1992, persons.Last());
            Company VolGU = new Company("VolGU", 10000000, 988, persons[0]);
            Company MSU = new Company("MSU", 10, 10101, persons[1]);
            Company[] companies = new[] { ArmaggedonsBlade, VolGU, MSU };
            foreach (var company in companies)
            {
                Console.WriteLine(company);
            }

            Console.WriteLine(p2 > p3 ? 1 : 2);
        }
    }
}
