using System;

class Program
{
    static void EvaluateEnum(System.Enum e)
    {
        Console.WriteLine("Information about {0}", e.GetType().Name);

        Console.WriteLine("Storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

        Array enumData = Enum.GetValues(e.GetType());
        Console.WriteLine("Enum has {0} members.", enumData.Length);
        foreach (var item in enumData)
        {
            Console.WriteLine("Name: {0}, Value: {0:D}", item);
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Fun with Enums");
        DayOfWeek day = DayOfWeek.Monday;
        ConsoleColor color = ConsoleColor.Black;
        
        EvaluateEnum(day);
        EvaluateEnum(color);
    }
}
