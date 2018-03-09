using System;
using System.Collections.Generic;
using System.Linq;
using Proper.Functional.Library.To.Compile;

namespace _08.CoreFunctions
{
    static class Ext
    {
        // 1. Map
        // Map is basically Select in LINQ
        // (IEnumerable<T>, (T → R)) → IEnumerable<R>
        public static IEnumerable<R> Map<T, R>
            (this IEnumerable<T> ts, Func<T, R> f)
            => ts.Select(f);

        // (Option<T>, (T → R)) → Option<R>
        public static Option<R> Map<T, R>
            (this LaYumba.Functional.Option.None _, Func<T, R> f)
            => None;

        public static Option<R> Map<T, R>
            (this LaYumba.Functional.Option.Some<T> some, Func<T, R> f)
            => Some(f(some.Value));

        public static Option<R> Map<T, R>
            (this Option<T> optT, Func<T, R> f)
            => optT.Match<R>(
                () => None,
                (t) => Some(f(t)));
        // Let C<T> indicate a generic “container” that wraps some inner
        // value(s) of type T. Then the signature of Map can be generally written as follows:
        // Map : (C<T>, (T → R)) → C<R>

        // 2. ForEach - generally foreach for actions
        public static IEnumerable<Unit> ForEach<T>
            (this IEnumerable<T> ts, Action<T> action)
            => ts.Map(action.ToFunc()).ToImmutableList();

        public static Option<Unit> ForEach<T>
            (this Option<T> opt, Action<T> action)
            => Map(opt, action.ToFunc());

        // 3. Bind
        // Option.Bind : (Option<T>, (T → Option<R>)) → Option<R>
        public static Option<R> Bind<T, R>
            (this Option<T> optT, Func<T, R> f)
            => optT.Match<R>(
                () => None,
                (t) => f(t));

        // similar to SelectMany LINQ
        public static IEnumerable<R> Bind<T, R>
            (this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
            {
                foreach (T t in ts)
                    foreach (R r in f(t))
                        yield return r;
            }
        //  monad is a type M<T> for which the following functions
        // are defined:
        // Return : T → M<T>
        // Bind : (M<T>, (T → C<R>)) → C<R>

        // 4. Where
        public static Option<T> Where<T>
         (this Option<T> optT, Func<T, bool> pred)
         => optT.Match(
             () => None,
             (t) => pred(t) ? optT : None);
    }
    // Option could be viewed as IEnumarable of count=1
    // Some usefule Bind functions 
    // The first overload can be used to get an IEnumerable<T>
    // where Map would give you an IEnumerable<Option<T>>,
    // The second overload can be used to get an IEnumerable<T>
    // where Map would give you an Option<IEnumerable<T>>.
    public struct Option<T>
    {
        public IEnumerable<T> AsEnumerable()
        {
            if (IsSome) yield return Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var opt = Some("John");
            // Map for logic, ForEach for side effects
            opt.Map(name => $"Hello {name}")
               .ForEach(WriteLine);

        }
    }
}
