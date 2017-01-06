using System;
using System.Linq;
using System.Reflection;

namespace DynReflection
{
    static class Reflector
    {
        private static bool HasProperties(dynamic obj, Type type)
        {
            return type.GetProperties().All(prop =>
            {
                try
                {
                    Console.WriteLine("Trying {0}", prop.Name);
                    PropertyInfo val = obj.GetType().GetProperty(prop.Name, prop.PropertyType);
                    Console.WriteLine("Got {0} {1}", val.Name, val.PropertyType);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed tp find property: {0}", e.Message);
                    return false;
                }
            });
        }

        public static bool IsValid(dynamic obj, Type type)
        {
            return HasProperties(obj, type);
        }
    }

    abstract class Parent
    {
        public int AbstractInt { get; set; }
    }

    class BaseClass : Parent
    {
        public int BaseX { get; set; }
    }

    class PlainClass : BaseClass
    {
        public int PublicIntProp { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Mere example of dynamic variable validation
            dynamic baseObj = new BaseClass { BaseX = 100 };
            dynamic testObj = new PlainClass { PublicIntProp = 10 };
            dynamic anonObj = new { X = 10 };
            Console.WriteLine("Object is valid: {0}", Reflector.IsValid(baseObj, typeof(BaseClass)));
            Console.WriteLine();
            Console.WriteLine("Object is valid: {0}", Reflector.IsValid(testObj, typeof(PlainClass)));
            Console.WriteLine();
            Console.WriteLine("Object is valid: {0}", Reflector.IsValid(anonObj, typeof(PlainClass)));
        }
    }
}
