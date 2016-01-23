using System;
using System.Collections.Generic;

namespace FunWithGenerics
{
    class Person
    {
        private class SortPeopleByAge : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age); // reuse int comparer
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", FirstName, LastName, Age);
        }

        public static IComparer<Person> SortByAge
        {
            get
            {
                return new SortPeopleByAge();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };

            // Print out # of items in List.
            Console.WriteLine("Items in list: {0}", people.Count);

            // Enumerate over list.
            foreach (Person p in people)
                Console.WriteLine(p);
            // Insert a new person.
            Console.WriteLine("\n->Inserting new person.");
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Items in list: {0}", people.Count);

            // Copy data into a new array.
            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++)
            {
                Console.WriteLine("First Names: {0}", arrayOfPeople[i].FirstName);
            }

            // Make some people with different ages.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(Person.SortByAge) // note the usage of property
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };

            // Note the items are sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // Add a few new people, with various ages.
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });
            // Still sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }

        }
    }
}
