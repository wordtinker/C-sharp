using System;

namespace OptionVSNewNull
{
    /// <summary>
    /// A very basic implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Option<T>
    {
        public abstract T Value { get; }
        public abstract TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);
    }
    public class None<T> : Option<T>
    {
        public override T Value => throw new NotSupportedException("There is no value");
        public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none) => none();
    }
    public class Some<T> : Option<T>
    {
        private T value;
        public override T Value => value;
        public Some(T value)
        {
            this.value = value;
        }
        public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none) => some(Value);
    }

    class Human { }

    class Program
    {
        static void PrintHuman(Human? human)
        {
            var toPrint = human switch
            {
                Human h => "a human",
                null => "not a human"
            };
            Console.WriteLine("That was: {0}", toPrint);
        }

        static void PrintOptionHuman(Option<Human> optHuman)
        {
            var toPrint = optHuman.Match(
                v => "a human",
                () => "not a human"
                );
            Console.WriteLine("That was: {0}", toPrint);
        }

        static void Main(string[] args)
        {
            Human? notSoHuman = null;
            Human? aHuman = new Human();
            PrintHuman(notSoHuman);
            PrintHuman(aHuman);

            Option<Human> notAnOption = new None<Human>();
            Option<Human> anOption = new Some<Human>(new Human());
            PrintOptionHuman(notAnOption);
            PrintOptionHuman(anOption);
        }
    }
}
