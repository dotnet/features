using System.Threading.Tasks;

namespace NETCatalog.CLI
{
    public class Program
    {
        public static async Task Main(string[] args) => await InteractiveCatalog.Start();
    }
}
