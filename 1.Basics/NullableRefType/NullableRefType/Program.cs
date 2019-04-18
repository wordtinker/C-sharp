using System;

namespace NullableRefType
{

    class Item
    {
        public void Do()
        {

        }
    }

    class Forgiving
    {
        public string Title { get; set; } = default!; // ! suppresses compiler warning
    }

    class Program
    {
        static void Main()
        {
            Item cantBeNull = new Item();
            Item? canBeNull = null; // no warning

            cantBeNull.Do();
            canBeNull?.Do(); // warning

            // Add this to .csproj file
            // < LangVersion > 8.0 </ LangVersion >
            // < NullableReferenceTypes > true </ NullableReferenceTypes >
            // < NullableContextOptions > enable </ NullableContextOptions >


        }
    }
}
