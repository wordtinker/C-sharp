using Unit = System.ValueTuple;
using System;

namespace _06.UnitType
{
    using static F;
    public static partial class F
    {
        public static Unit Unit() => default(Unit);
    }

    public static class ActionExt
    {
        public static Func<Unit> ToFunc(this Action action)
            => () => { action(); return Unit(); };
        // ... more overloads for every Action
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Use void to indicate the absence of data, meaning that your function is only called for side
            // effects and returns no information.
            // Use Unit as an alternative, more flexible representation when there’s a need for
            // consistency in the handling of Func and Action.
        }
    }
}
