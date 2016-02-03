using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Type \"Exit\" to leave, or \"Go\" to continue.");
                string choice = Console.ReadLine();
                if (choice == "Exit")
                {
                    break;
                }
                else if (choice == "Go")
                {
                    Console.WriteLine("Enter X coord:");
                    int xCoord = 0;
                    int.TryParse(Console.ReadLine(), out xCoord);
                    int xCoordFinal = (0 <= xCoord && xCoord <= Console.WindowWidth) ? xCoord : 0;
                    Console.SetCursorPosition(xCoordFinal, Console.CursorTop);
                    Console.WriteLine("x");
                }
            }
        }
    }
}
