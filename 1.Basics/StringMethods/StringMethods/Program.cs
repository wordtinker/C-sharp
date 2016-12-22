using System;

namespace StringMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy", ""));
            Console.WriteLine();

            Console.WriteLine("=> String concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2;
            Console.WriteLine(s3);
            Console.WriteLine();

            Console.WriteLine("=> Escape characters:\a"); // \a Beep
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a "; // \t Tab
            Console.WriteLine(strWithTabs);

            // The following string is printed verbatim,
            // thus all escape characters are displayed.
            Console.WriteLine(@"C:\MyApp\bin\Debug");
            // White space is preserved with verbatim strings.
            string myLongString = @"This is a very
                very
                    very
                        long string";
            Console.WriteLine(myLongString);

            // string interpolation
            int x = 4;
            // old way
            Console.WriteLine("A square has {0} sides.", x);
            Console.WriteLine($"A square has {x} sides.");
        }
    }
}
