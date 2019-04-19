using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsynchronousStream
{
    class Program
    {

        // IProgress<int> progress is no longer needed
        // CancellationToken can be passed as parameter to
        // GenerateSeq(CancellationToken) is needed
        static async IAsyncEnumerable<int> GenerateSeq()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        static async Task Main()
        {
            await foreach (var item in GenerateSeq())
            {
                Console.WriteLine(item);
            }
        }
    }
}
