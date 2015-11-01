using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Person
    {
        private static int personCounter = 0;

        private string initials = null;

        public Person(string init)
        {
            this.initials = init;
            personCounter += 1;
        }

        public static int GetPersonCount()
        {
            return Person.personCounter;
        }

        public string Initials
        {
            get
            {
                Console.WriteLine("Getting initials.");
                return initials;
            }
            set
            {
                Console.WriteLine("Setting initials to: {0}", value);
                initials = value;
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter initials:");
            Person[] people = new Person[10];
            for (int i = 0; Person.GetPersonCount() < people.Length; i++)
            {
                people[i] = new Person(Console.ReadLine());
                people[i].Initials += "!";
            }

        }
    }
}
