using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MainAndGeneralised
{
    class Program
    {
        // C# 7.0 introduces the ability to define custom return types on async methods.
        // The key requirement is implementing the GetAwaiter  method.  The
        // System.Threading.Tasks.ValueTask<T>  provides an example of such
        // a custom type.  It is designed for the very scenario when the return value might be known immediately
        public static async ValueTask<long> GetDirectorySize(string path, string searchPattern)
        {
            if (!Directory.EnumerateFileSystemEntries(path, searchPattern).Any())
                return 0;
            else
                return await Task.Run(() => Directory.GetFiles(path, searchPattern,
                    SearchOption.AllDirectories).Sum(t => (new FileInfo(t).Length)));
        }
        static async Task Main(string[] args)
        {
            // since 7.0 main could be async
            var dirSize = await GetDirectorySize("some dir", "some pattern");
        }
    }
}
