using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace NETCatalog.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InteractiveCatalog.Start().Wait();
        }
    }
}
