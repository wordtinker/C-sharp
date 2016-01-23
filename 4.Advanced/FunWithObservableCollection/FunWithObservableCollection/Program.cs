using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FunWithObservableCollection
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
                return (IComparer<Person>)new SortPeopleByAge();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Make a collection to observe and add a few Person objects.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
        {
            new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
            new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
        };
            // Wire up the CollectionChanged event.
            people.CollectionChanged += people_CollectionChanged;

            Person john = new Person { FirstName = "John", LastName = "Murphy", Age = 50 };
            people.Add(john);
            people.Remove(john);
        }

        static void people_CollectionChanged(object sender,
    System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // What was the action that caused the event?
            Console.WriteLine("Action for this event: {0}", e.Action);
            // They removed something.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:");
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }
            // They added something.
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Now show the NEW items that were inserted.
                Console.WriteLine("Here are the NEW items:");
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }
}
