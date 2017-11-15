using System;

namespace Encapsulation
{
    class Employee
    {
        // Field data.
        private string empName;
        private float currPay;

        // Accessor (get method) -- traditional approach
        public string GetName()
        {
            return empName;
        }
        // Mutator (set method).
        public void SetName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
                Console.WriteLine("Error! Name must be less than 16 characters!");
            else
                empName = name;
        }
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
        // Properties with expression body, 7.0
        // same is valid for ctor, finalizer, and methods
        public string NewName
        {
            get => empName;
            set => empName = value;
        }

        // Automatic property
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
        public void GiveBonus(float amount)
        {
            currPay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", EmpID);
            Console.WriteLine("Pay: {0}", currPay);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Encapsulation *****\n");
            Employee emp = new Employee("Marvin", 456, 30000);
            emp.GiveBonus(1000);
            emp.DisplayStats();
            // Use the get/set methods to interact with the object's name.
            emp.SetName("Marv");
            Console.WriteLine("Employee is named: {0}", emp.GetName());
            Console.ReadLine();
            emp.Name = "Marv2";
            Console.WriteLine("Employee is named: {0}", emp.GetName());
            Console.ReadLine();
        }
    }
}
