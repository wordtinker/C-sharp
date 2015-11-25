using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with ADO.NET EF *****\n");
            PrintAllInventory();
            Console.WriteLine("***** Add new record to DB *****\n");
            AddNewRecord();
            UpdateRecord();
            PrintAllInventory();
            Console.ReadLine();

        }

        private static void PrintAllInventory()
        {
            using(AutoLotEntities context = new AutoLotEntities())
            {
                foreach (Car item in context.Cars)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void AddNewRecord()
        {
            // Add record to the Inventory table of the AutoLot
            // database.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    // Hard-code data for a new record, for testing.
                    context.Cars.Add(new Car()
                    {
                        CarID = 2222,
                        Make = "Yugo",
                        Color = "Brown"
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }
        private static void UpdateRecord()
        {
            // Find a car to delete by primary key.
            using (AutoLotEntities context = new AutoLotEntities())
            {
                Car carToUpdate = (from c in context.Cars
                                  where c.CarID == 2222
                                  select c).FirstOrDefault();

                if (carToUpdate != null)
                {
                    carToUpdate.Color = "Blue";
                    context.SaveChanges();
                }
            }
        }
    }
}
