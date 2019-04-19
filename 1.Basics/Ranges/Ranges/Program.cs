using System;

namespace Ranges
{
    class Program
    {

        static void Main(string[] args)
        {
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };

            Console.WriteLine($"The last word is {words[^1]}"); // dog
            var quickBrownFox = words[1..4];
            var lazyDog = words[^2..^0];
            var allWords = words[..]; // contains "The" through "dog".
            var firstPhrase = words[..4]; // contains "The" through "fox"
            var lastPhrase = words[6..]; // contains "the, "lazy" and "dog"
            Range phrase = 1..4;
            var text = words[phrase];
        }
    }
}
