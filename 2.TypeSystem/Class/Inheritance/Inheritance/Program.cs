using System;


namespace Inheritance
{
    // This new type will function as a contained class.
    class BenefitPackage
    {
        // Assume we have other members that represent
        // dental/health benefits, and so on.
        public double ComputePayDeduction()
        {
            return 125.0;
        }
    }

    class Employee
    {
        // Field data.
        private string empName;
        private float currPay;
        // Contain a BenefitPackage object.
        protected BenefitPackage empBenefits = new BenefitPackage();

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
        public int Age { get; set; }
        // Expose object through a custom property.
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

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

        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("ID: {0}", EmpID);
            Console.WriteLine("Pay: {0}", currPay);
        }
    }

    // Managers need to know their number of stock options.
    class Manager : Employee // inheritance
    {
        public int StockOptions { get; set; }
    }


    sealed class SalesPerson : Employee // // won't be able to inherit from SalesPerson
    {
        public int SalesNumber { get; set; }

        public SalesPerson () { }

        public SalesPerson(string name, int id, float pay, int salesNumber)
            : base(name, id, pay) // call to the parent class ctor.
        {
            SalesNumber = salesNumber;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            SalesPerson fred = new SalesPerson();
            fred.Age = 31;
            fred.Name = "Fred";
            fred.SalesNumber = 50;
            fred.DisplayStats();
            double cost = fred.GetBenefitCost();
            Console.WriteLine("Benefit cost: {0}", cost);
            Console.ReadLine();
        }
    }
}
