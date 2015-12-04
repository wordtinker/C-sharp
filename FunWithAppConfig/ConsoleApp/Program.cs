using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // NB>> Add reference System.configuration

            // Read non-existing param from App.config
            string value = ConfigurationManager.AppSettings["notHere"];
            Console.WriteLine("The value is null: {0}", (value == null).ToString());

            // Read normal value from App.config
            value = ConfigurationManager.AppSettings["param"];
            Console.WriteLine("The value is: {0}", value);

            // Read empty value from App.config
            value = ConfigurationManager.AppSettings["empty"];
            Console.WriteLine("The string is empty: {0}", (value == "").ToString());


        }
    }
}
