using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class InteractiveCatalog
{
    static HttpClient _client = new HttpClient();
    static string _url = "http://dotnet-features.azurewebsites.net/topics";

    public static async Task Start()
    {
        string line = String.Empty;
        string category = null;

        do
        {
            Console.Clear();

            if (category == null)
            {

            }

            category = await GetCatalogEntry(category, line);
        } while ((line = Console.ReadLine()) != null);

    }

    private static async Task<string> GetCatalogEntry(string category, string concept)
    {

        if (category == null)
        {
            var catalogEntry = await _client.GetStringAsync(_url);
            var categories = SplitLines(catalogEntry);

            Console.WriteLine("Categories you can learn more about:\n");
            foreach (var c in categories)
            {
                Console.WriteLine($"\t{c}");
            }
            return null;
        }
        else if (concept == null)
        {
            var catalogEntry = await _client.GetStringAsync($"{_url}/{category}");
            var concepts = SplitLines(catalogEntry);

            Console.WriteLine($"Concepts under /{category}/ you can learn more about:\n");
            foreach (var c in concepts)
            {
                Console.WriteLine($"\t{c}");
            }
            return category;
        }
        else 
        {
            var catalogEntry = await _client.GetStringAsync($"{_url}/{category}/{concept}");
            Console.WriteLine(catalogEntry);
            return category;
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