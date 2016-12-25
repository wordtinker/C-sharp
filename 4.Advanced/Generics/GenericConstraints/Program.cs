using System;
using System.Collections.Generic;

namespace GenericConstraints
{
    class SomeClass { }
    interface ISomeInterface { }

    class GenericClass<T, U>
        where T : SomeClass, ISomeInterface // T must derive from SomeClass and implement ISomeInterface
        where U : new() // U must provide parameterless ctor
    {

        // Methods can use constraints too
        // Method returns subset of N elements derived from T
        Stack<N> FilteredStack<N>() where N : T
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
