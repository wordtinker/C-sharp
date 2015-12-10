using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyClass
    {
        public string Param {get; set;}
        public int NonImportantParam { get; set; }

        public override bool Equals(object obj)
        {
            MyClass item = obj as MyClass;
            if (item == null)
            {
                return false;
            }

            return this.Param == item.Param;
        }
        public override int GetHashCode()
        {
            return this.Param.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass objectOne = new MyClass { Param = "Something", NonImportantParam = 10 };
            MyClass objectTwo = new MyClass { Param = "Something", NonImportantParam = 20 };

            Console.WriteLine("ObjectOne == objectTwo ? {0}", (objectOne==objectTwo).ToString());
            Console.WriteLine("ObjectOne equals to objectTwo ? {0}", (objectOne.Equals(objectTwo)).ToString());

            List<MyClass> myList = new List<MyClass>
            {
                new MyClass{ Param = "Something!", NonImportantParam = 10 },
                new MyClass{ Param = "Something", NonImportantParam = 20 }
            };

            List<MyClass> anotherList = new List<MyClass>
            {
                new MyClass{ Param = "!Something", NonImportantParam = 10 },
                new MyClass{ Param = "Something", NonImportantParam = 30 }
            };

            Console.WriteLine("objectOne in the list one at pos : {0}", myList.IndexOf(objectOne));
            Console.WriteLine("objectOne in the list two at pos : {0}", anotherList.IndexOf(objectOne));
            Console.WriteLine("Both list have in common:");
            foreach (var item in myList.Intersect(anotherList))
            {
                Console.WriteLine("\t {0}", item.Param);
            }
        }
    }
}
