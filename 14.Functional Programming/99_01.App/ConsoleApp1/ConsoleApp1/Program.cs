using LanguageExt;
using static LanguageExt.Prelude;
using System;
using static ConsoleApp1.UnboundIO;
using static ConsoleApp1.Functional;

namespace ConsoleApp1
{

    static class UnboundIO
    {
        public static string Read(bool guard) => guard ? "Some string" : throw new Exception("Can't read.");
        public static void Write(string s, bool guard)
        {
            if (!guard) throw new Exception("Can't write");
            Console.WriteLine($"Wrote: {s}");
        }
    }

    static class Functional
    {
        public static Try<string> Convert(string s, bool guard) => ()
            => guard ? "Converted" : throw new Exception("Conversion error.");
        public static Option<string> ConvertMore(string s, bool guard)
        {
            if (guard) return "Everything is Ok";
            else return None;
        }
    }

    class Program
    {
        /// <summary>
        /// With this approach
        /// - impure function do nothing FP style, calling code is
        ///   1) wrapped with Try<a>
        ///   2) calling from IO context making it bound to it
        /// - pure functions are wrapped in Try<a> 
        /// </summary>
        static void DoUnbound(bool read, bool convert, bool convert2, bool write)
        {
            Console.WriteLine("-----------------");
            try
            {
                string fromReader = Read(read);
                Convert(fromReader, convert)
                .Map(s => ConvertMore(s, convert2))
                .IfFailThrow()
                .Iter(s => Write(s, write));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Handled an exception.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("-----------------");
                Console.WriteLine();
            }
        }
        /// <summary>
        /// The main questions are:
        /// - should we wrap impure (IO etc..) function into open monads for the 
        /// sake of visual code purity
        /// - if pure function throws should it be honest and return bound value instead
        /// e.g. 10 `div` 0 a -> a -> a or a -> a -> Either a
        /// </summary>
        static void Main(string[] args)
        {
            DoUnbound(false, false, false, false);
            DoUnbound(true, false, false, false);
            DoUnbound(true, true, false, false);
            DoUnbound(true, true, true, false);
            DoUnbound(true, true, true, true);
        }
    }
}
