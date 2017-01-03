using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineTunedCollections
{
    public class Animal
    {
        public string Name { get; set; }
        public int Popularity { get; set; }
        public Zoo Zoo { get; internal set; } // backreference to zoo
    }

    // Collection<T> allows to reimplement insertion/deletion methods
    public class AnimalCollection : Collection<Animal>
    {
        Zoo zoo;
        public AnimalCollection(Zoo zoo)
        {
            this.zoo = zoo;
        }

        protected override void InsertItem(int index, Animal item)
        {
            base.InsertItem(index, item);
            item.Zoo = zoo;
        }

        protected override void SetItem(int index, Animal item)
        {
            base.SetItem(index, item);
            item.Zoo = zoo;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Zoo = null;
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach (Animal a in this) 
            {
                a.Zoo = null;
            }
            base.ClearItems();
        }
    }

    public class Zoo
    {
        public readonly AnimalCollection Animals;
        public Zoo()
        {
            Animals = new AnimalCollection(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Animals.Add(new Animal { Name = "Lion", Popularity = 10 });
            zoo.Animals.Add(new Animal { Name = "Sea Lion", Popularity = 20 });
            foreach (Animal a in zoo.Animals) Console.WriteLine(a.Name);        }
    }
}
