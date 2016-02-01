using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace ConsoleApplication1
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public bool Registered { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var registeredUsers = new List<Person>();
            registeredUsers.Add(new Person() { PersonID = 1, Name = "Bryon Hetrick", Registered = true });
            registeredUsers.Add(new Person() { PersonID = 2, Name = "Nicole Wilcox", Registered = true });
            registeredUsers.Add(new Person() { PersonID = 3, Name = "Adrian Martinson", Registered = false });
            registeredUsers.Add(new Person() { PersonID = 4, Name = "Nora Osborn", Registered = false });

            var serializer = new JavaScriptSerializer();
            string serializedResult = serializer.Serialize(registeredUsers);

            File.WriteAllText(@"C:\_test\some.json", serializedResult);

            string newJson = File.ReadAllText(@"C:\_test\some.json");
            List<Person> obj = serializer.Deserialize<List<Person>>(newJson);
            obj.ForEach(x => System.Console.WriteLine(x.Name));

            ////////////////////////////////////////////////////////////////
            //var ptrn = new Dictionary<string, string[]>
            //    {
            //        { "$1", new string[]{"blah", "blah1" } },
            //        { "$2", new string[]{"blah", "blah1" } }
            //    };
            //var plugin = new Plugin
            //{
            //    Prefix = new string[] { "prefix1", "prefix2" },
            //    Patterns = new Dictionary<string, Dictionary<string, string[]>>
            //    {
            //        {"0", ptrn}
            //    }
            //};
            //serializer = new JavaScriptSerializer();
            //string result = serializer.Serialize(plugin);
            //File.WriteAllText(@"C:\_test\lang.json", result);

            string ptrns = File.ReadAllText(@"C:\_test\Hebrew.json");
            Plugin plug = serializer.Deserialize<Plugin>(ptrns);
            // Print all prefixes
            //System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (var item in plug.Prefixes)
            {
                System.Console.WriteLine(string.Format("Prefix -> {0}", item));
            }
            // Print all patterns from level "0"
            foreach (var item in plug.Patterns)
            {
                System.Console.WriteLine(string.Format("Level: {0}", item.Key));
                foreach (var patterns in item.Value)
                {
                    System.Console.WriteLine(string.Format("\tPattern: {0}", patterns.Key));
                    foreach (var i in patterns.Value)
                    {
                        System.Console.WriteLine(string.Format("\t\t -> {0}", i));
                    }
                    
                }

            }

        }
    }

    class Plugin
    {
        public Dictionary<string, Dictionary<string, string[]>> Patterns { get; set; }
        public string[] Prefixes { get; set; }
    }
}
