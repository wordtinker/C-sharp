using System;
using static Functional.F;
using Functional;

namespace Functional
{
    public static partial class F
    {
        public static Option.None None
            => Option.None.Default;
        public static Option.Some<T> Some<T>(T value)
            => new Option.Some<T>(value); // wrap the given value into a Some
    }
    public struct Option<T>
    {
        readonly bool isSome;
        readonly T value;

        private Option(T value)
        {
            this.isSome = true;
            this.value = value;
        }

        // Converts None into an Option
        // default ctor yield isSome = false, and value = default(T)
        public static implicit operator Option<T>(Option.None _)
            => new Option<T>();
        // Converts Some into an Option
        public static implicit operator Option<T>(Option.Some<T> some)
            => new Option<T>(some.Value);
        // Converts value into an Option
        public static implicit operator Option<T>(T value)
            => value == null ? new Option<T>() : new Option<T>(value); 
        // takes two functions and evaluates one or another
        // based on state of the Option
        public R Match<R>(Func<R> None, Func<T, R> Some)
          => isSome ? Some(value) : None();
    }
}

namespace Option
{
    public struct None
    {
        // Non has no members, it contains no data.
        internal static readonly None Default = new None();
    }
    public struct Some<T>
    {
        // wraps a value
        internal T Value { get; }
        internal Some(T value)
        {
            // some value must be present
            if (value == null)
                throw new ArgumentNullException();
            Value = value;
        }
    }
}

namespace _07.OptionType
{
    class Subscriber
    {
        public Option<string> Name { get; set; }
        public string Email { get; set; }    }

    class Program
    {
        public static string GreetingFor(Subscriber subscriber)
            => subscriber.Name.Match(
                None: () => "Dear Subscriber,",
                Some: (name) => $"dear {name.ToUpper()},");

        static void Main(string[] args)
        {
            // Option<T> = None | Some(T)
            // None—A special value indicating the absence of a value. If the Option has no inner value,
            // we say that “the Option is None.”
            // Some(T)—A container that wraps a value of type T.If the Option has an inner value, we say
            // that “the Option is Some.”
            var firstName = Some("Enrico");            var middleName = None;            Console.WriteLine(GreetingFor(                new Subscriber
                {
                    Name = "John"
                }));        }
    }
}
