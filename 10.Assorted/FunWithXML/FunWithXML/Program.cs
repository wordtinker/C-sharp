using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FunWithXML
{

    static class Extensions
    {
        public static XElement ToXElement<T>(this object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
                }
            }
        }

        public static T FromXElement<T>(this XElement xElement)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(xElement.CreateReader());
        }
    }


    public class Task
    {
        public string Text { get; set; }
        public int ID { get; set; }
    }

    class Program
    {
        static string fileName = @"C:\_test\text.xml";

        static void Main(string[] args)
        {
            // 1. Create XML File
            XDocument tree = new XDocument(
                new XElement("Root",
                    new XElement("Tasks")
                )
                );
            tree.Save(fileName);

            // 2. Read from file
            XDocument newTree = XDocument.Load(fileName);
            Console.WriteLine(newTree.ToString());

            // 3. Add element with attributes
            XElement task = new XElement("Task", "Do something");
            task.SetAttributeValue("id", 1);
            task.SetAttributeValue("category", "Money");
            newTree.Root.Element("Tasks").Add(task);
            newTree.Save(fileName);
            Console.WriteLine(newTree.ToString());

            // 4. Serialize and add
            Task person = new Task { Text = "Do other thing", ID = 1 };

            XElement elem = person.ToXElement<Task>();
            newTree.Root.Element("Tasks").Add(elem);
            Console.WriteLine(newTree.ToString());

            //XDocument anotherTree = new XDocument();
            //XmlSerializer s = new XmlSerializer(typeof(Person));
            //using (XmlWriter writer = anotherTree.CreateWriter())
            //{
            //    s.Serialize(writer, person);
            //}

            // 5. Select element
            // in that form t.Value wont be null
            var selectedElem = (from t in newTree.Root.Element("Tasks").Elements("Task").Elements("ID")
                               where t.Value == "1"
                               select t.Parent).FirstOrDefault();

            // 6. Deserialize
            Task restored = selectedElem.FromXElement<Task>();
            Console.WriteLine("{0} {1}",restored.ID, restored.Text);

            // 7. Update
            restored.Text = "Another text";
            selectedElem.ReplaceWith(restored.ToXElement<Task>());
            Console.WriteLine(newTree);

            // 8. Delete
            selectedElem = (from t in newTree.Root.Element("Tasks").Elements("Task").Elements("ID")
                                where t.Value == "1"
                                select t.Parent).FirstOrDefault();
            selectedElem.Remove();
            Console.WriteLine(newTree);

            newTree.Save(fileName);
        }
    }
}
