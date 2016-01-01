
using System;

namespace Enums
{
    enum EmpType // Default type is System.Int32
    {
        Manager, // = 0
        Grunt, // = 1
        Contractor, // = 2
        VicePresident // = 3
    }

    enum CustomEmpType
    {
        Manager = 102,
        Grunt, // = 103
        Contractor, // = 104
        VicePresident // = 105
    }

    enum NonSequentialEmpType : byte // Could force to save memory
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
    }

    class Program
    {
        // Enums as parameters.
        static void AskForBonus(EmpType e)
        {
            switch (e) // Enums as switch cases
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Enums *****");
            // Make a contractor type.
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            // Print storage for the enum.
            Console.WriteLine("EmpType uses a {0} for storage",
                Enum.GetUnderlyingType(emp.GetType()));
            Console.WriteLine("EmpType uses a {0} for storage",
                Enum.GetUnderlyingType(typeof(NonSequentialEmpType))); // No instance is used

            // Get all name/value pairs for enum.
            Array enumData = Enum.GetValues(typeof(EmpType));
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                enumData.GetValue(i));
            }
        }
    }
}
