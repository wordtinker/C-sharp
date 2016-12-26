using System;

namespace InvocationList
{
    // All delegates inherit methods from System.Delegates
    // Delegate.Combine()
    // Delegate.Remove()
    // shortcuted with +,+=,-,-=
    // when delegate is invoked, all methods from
    // invocation list are invoked
    delegate void StringProcessor(string input);

    class Person
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }
        public void SayTheMessage(string message)
        {
            Console.WriteLine($"{name} says: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person john = new Person("John");
            Person tom = new Person("Tom");
            StringProcessor johnsVoice = john.SayTheMessage;
            StringProcessor tomsVoice = tom.SayTheMessage;
            StringProcessor combined = johnsVoice + tomsVoice;

            Console.WriteLine("Both people say.");
            combined("Hi");

            combined -= tomsVoice;
            Console.WriteLine("Only John will speak");
            combined("Hello");
        }
    }
}
