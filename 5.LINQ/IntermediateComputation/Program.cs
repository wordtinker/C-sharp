using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateComputation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] AllUsers = { "Peter", "Mark", "Archibald", "Paul" };
            // Print name and name length, ordered by length
            var query = from user in AllUsers
                        orderby user.Length
                        select user;
            foreach (var item in query)
            {
                Console.WriteLine("{0}: {1}", item.Length, item);
            }
            Console.WriteLine();
            // Suppose Length call is resource heavy
            // introduce new let variable that is calculated once
            var newQuery = from user in AllUsers
                           let length = user.Length
                           orderby length
                           select new { Name = user, Length = length };

            foreach (var entry in newQuery)
            {
                Console.WriteLine("{0}: {1}", entry.Length, entry.Name);
            }
        }
    }
}
