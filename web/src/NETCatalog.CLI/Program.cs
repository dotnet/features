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
            var url = "http://dotnet-buildtwentysixteendemo.azurewebsites.net/topics";

            var client = new HttpClient();

            string text = string.Empty;

            switch (args.Length)
            {
                case 0:
                    text = client.GetStringAsync(url).Result;
                    var categories = SplitLines(text);

                    Console.WriteLine("Categories you can learn more about:\n");
                    foreach (var c in categories)
                    {
                        Console.WriteLine($"\t{c}");
                    }

                    break;
                case 1:
                    text = client.GetStringAsync($"{url}/{args[0]}").Result;
                    var concepts = SplitLines(text);

                    Console.WriteLine($"Concepts under /{args[0]}/ you can learn more about:\n");
                    foreach (var c in concepts)
                    {
                        Console.WriteLine($"\t{c}");
                    }

                    break;
                case 2:
                    var concept = client.GetStringAsync($"{url}/{args[0]}/{args[1]}").Result;
                    Console.WriteLine(concept);
                    break;
            }
        }

        private static IEnumerable<string> SplitLines(string text)
        {
            using (var reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }
    }
}
