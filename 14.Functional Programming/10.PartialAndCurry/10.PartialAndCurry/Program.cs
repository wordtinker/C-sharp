using System;
using static System.Console;
using Name = System.String;
using Greeting = System.String;
using PersonalizedGreeting = System.String;
using static LanguageExt.Prelude;

namespace _10.PartialAndCurry
{
    static class Partial
    {
        public static Func<T2, R> Apply<T1, T2, R>
            (this Func<T1, T2, R> f, T1 t1)
            => t2 => f(t1, t2);
        public static Func<T2, T3, R> Apply<T1, T2, T3, R>
            (this Func<T1, T2, T3, R> f, T1 t1)
            => (t2, t3) => f(t1, t2, t3);
    }

    class Program
    {
        static Func<Greeting, Name, PersonalizedGreeting> greet
            = (gr, name) => $"{gr}, {name}";

        static void Main(string[] args)
        {
            // Simple approach
            Name[] names = { "Tristan", "Ivan" };
            names.Map(g => greet("Hello", g)).Iter(WriteLine);
            // Partial application
            var greetInformally = greet.Apply("Hey");
            names.Map(greetInformally).Iter(WriteLine);
            // Curry
            var curried = curry(greet);
            var greetNostalgically = curried("Arrividerci");
            names.Map(greetNostalgically).Iter(WriteLine);
        }
    }
}
