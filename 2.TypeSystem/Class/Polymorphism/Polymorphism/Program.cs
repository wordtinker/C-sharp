using System;

namespace Polymorphism
{
    abstract class Employee
    {
        // Field data.
        private string empName;
        private float currPay;
        
        // Properties!
        public string Name
        {
            get { return empName; } // omit to make it write only
            set // omit to make it read only
            {
                if (value.Length > 15)
                    Console.WriteLine("Error! Name must be less than 16 characters!");
                else
                    empName = value;
            }
        }

        public int EmpID { get; set; }
        
        // Constructors.
        public Employee() { }
        public Employee(string name, int id, float pay)
        {
            Name = name; // Property is used here to enforce business rules.
            EmpID = id;
            currPay = pay;
        }
        // Methods.
        public virtual void GiveBonus(float amount) // Add some polymorphism
        {
            currPay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", EmpID);
            Console.WriteLine("Pay: {0}", currPay);
        }
    }

    // Managers need to know their number of stock options.
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager() { }

        public Manager(string name, int id, float pay, int stocksNumber)
            : base(name, id, pay)
        {
            StockOptions = stocksNumber;
        }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Stock Options: {0}", StockOptions);
        }
    }


    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson() { }

        public SalesPerson(string name, int id, float pay, int salesNumber)
            : base(name, id, pay) // call to the parent class ctor.
        {
            SalesNumber = salesNumber;
        }
        // A salesperson's bonus is influenced by the number of sales.
        public sealed override void GiveBonus(float amount) // wont be able to change in subclass
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
                salesBonus = 10;
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                    salesBonus = 15;
                else
                    salesBonus = 20;
            }
            base.GiveBonus(amount * salesBonus);
        }

        public new void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Sales: {0}", SalesNumber);
        }
    }

    class Program
    {
        public static void PrintStars(object o)
        {
            if (o is null) return;     // constant pattern "null"
            if (!(o is int i)) return; // type pattern "int i"
            Console.WriteLine(new string('*', i));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");

            // Give each employee a bonus?
            Employee chucky = new Manager("Chucky", 50, 100000, 9000);
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            Console.WriteLine();

            Employee fran = new SalesPerson("Fran", 43, 3000, 31);
            fran.GiveBonus(200);
            fran.DisplayStats(); // Watch the effect of method's new keyword here
            Console.ReadLine();

            // Casting
            Manager toManager = (Manager)chucky; // Explicit cast
            // as keyword
            Manager isItAManager = chucky as Manager;
            if (isItAManager == null)
            {
                Console.WriteLine("Sorry he is not a manager!");
            }
            // is keyword
            if (chucky is Manager)
            {
                Console.WriteLine("He is manager.");
            }
            // C# 7.0 introduces the notion of patterns, which,
            // abstractly speaking, are syntactic elements that can test that a value has
            // a certain "shape", and extract information from the value when it does
            PrintStars(3);
            object o = "10";
            if (o is int i || (o is string s && int.TryParse(s, out i)))
            {
                Console.WriteLine("i is: {0}", i);
                /* use i */
            }
        }
    }
}
