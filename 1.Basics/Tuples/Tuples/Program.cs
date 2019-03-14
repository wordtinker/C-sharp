using System;

namespace Tuples
{
    class Program
    {
        static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string.", true);
        }

        static void Main(string[] args)
        {
            (string, int, string) tuple = ("a", 5, "b");
            Console.WriteLine("First item: {0}", tuple.Item1); // note name
            (string GoodName, int) leftName = ("a", 5); // Assign name
            var rightName = (GoodName: "a", 5); // NB only if left part not presented or var
            Console.WriteLine("First item: {0}", leftName.GoodName);
            Console.WriteLine("First item: {0}", rightName.GoodName);

            Console.WriteLine("=> Inferred Tuple Names"); // 7.1+ only
            var foo = new { Prop1 = "first", Prop2 = "second" };
            var bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine($"{bar.Prop1};{bar.Prop2}");

            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"String is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}");

        }
    }
}
