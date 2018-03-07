// watch 'static' here
using System;
using System.Threading.Tasks;
using static System.Console;
using static System.Linq.Enumerable;

namespace FirstThesis
{
    class Program
    {
        static void Main(string[] args)
        {
            // We need this elements for FP
            // - functiona as first order class values
            // - avoid state mutations
            var nums = Range(-10_000, 20_001).Reverse().ToList();
            Action task1 = () => WriteLine(nums.Sum());
            Action task2 = () => { nums.Sort(); WriteLine(nums.Sum()); };
            Action task3 = () => WriteLine(nums.OrderBy(x => x).Sum());

            // this will mess the state of nums.
            Parallel.Invoke(task1, task2);
            WriteLine("-------");
            // this will not
            Parallel.Invoke(task1, task3);
        }
    }
}
