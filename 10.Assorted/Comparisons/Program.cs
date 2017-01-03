using System;
using System.Collections.Generic;
using System.Linq;

namespace Comparisons
{
    class Wish : IComparable<Wish>, IComparable
    {
        private class NameCompaper : Comparer<Wish>
        {
            public override int Compare(Wish x, Wish y)
            {
                if (Equals(x, y)) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                return x.Name.CompareTo(y.Name);
            }
        }

        public static Comparer<Wish> SortByName { get
            {
                return new NameCompaper();
            }
        }

        public string Name { get; set; }
        public int Priority { get; set; }

        public int CompareTo(Wish other)
        {
            if (Equals(other)) return 0;
            if (other == null) return 1;
            return Priority.CompareTo(other.Priority);
        }

        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Wish))
                throw new InvalidOperationException("CompareTo: Not a Wish");
            return CompareTo((Wish)obj);        }

        public override string ToString()
        {
            return $"{Name} :: {Priority}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var wishList = new List<Wish>
            {
                new Wish { Name="Peace", Priority=2 },
                null,
                new Wish { Name="Wealth", Priority=3 },
                new Wish { Name="Love", Priority=2 },
                new Wish { Name="3 more wishes", Priority=1 },
                null
            };
            Console.WriteLine("Print unsorted");
            foreach (Wish item in wishList)
            {
                Console.WriteLine(item);
            }
            // Default sort with IComparable
            wishList.Sort();
            Console.WriteLine("Print sorted with IComparable");
            foreach (Wish item in wishList)
            {
                Console.WriteLine(item);
            }
            // Custom sort with IComparer
            wishList.Sort(Wish.SortByName);
            Console.WriteLine("Print sorted with IComparer");
            foreach (Wish item in wishList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Print sorted with Extension method");
            // Same result with extension method
            foreach (Wish item in wishList.OrderBy(w => w?.Name))
            {
                Console.WriteLine(item);
            }
            // Same with Query
            var query = from wish in wishList
                        orderby wish?.Name
                        select wish;
            foreach (Wish item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
