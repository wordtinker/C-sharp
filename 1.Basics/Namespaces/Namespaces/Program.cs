using System; // Import every member from that namespace

namespace Namespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use fully qualified name
            // Also add this one to referenced assemblies.
            System.Windows.Forms.MessageBox.Show("Hello World");
        }
    }
}
