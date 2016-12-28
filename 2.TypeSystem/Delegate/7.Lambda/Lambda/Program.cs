using System;
using System.Collections.Generic;

namespace Lambda
{
    class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            
            // Syntax of the anonymous delegate
            Func<string, int> returnLength;
            returnLength = delegate (string text) { return text.Length; };
            Console.WriteLine(returnLength("Hello"));

            // lambda syntax
            returnLength = text => text.Length;
            Console.WriteLine(returnLength("Hello"));

            // lambdas for lists
            var films = new List<Film>
            {
                new Film { Name = "Jaws", Year = 1975 },
                new Film { Name = "Singing in the Rain", Year = 1952 },
                new Film { Name = "Some like it Hot", Year = 1959 },
                new Film { Name = "The Wizard of Oz", Year = 1939 },
                new Film { Name = "It's a Wonderful Life", Year = 1946 },
                new Film { Name = "American Beauty", Year = 1999 },
                new Film { Name = "High Fidelity", Year = 2000 },
                new Film { Name = "The Usual Suspects", Year = 1995 }
            };

            Action<Film> print = film =>
                Console.WriteLine("Name={0}, Year={1}", film.Name, film.Year);

            films.ForEach(print);
            Console.WriteLine();

            films.FindAll(film => film.Year < 1960).ForEach(print);
            Console.WriteLine();

            films.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            films.ForEach(print);
            Console.ReadLine();
        }
    }
}
