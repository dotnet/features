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
        string response = null;
        string category = null;
        string[] state = null;

        while (true)
        {

        }

        do
        {
            if (response == null && state == null)
            {}
            else if (response == String.Empty && state == null)
            {
                return;
            }
            else if (response != string.Empty && state == null)
            {
                category = response;
                response = null;
            }
            else if (response == string.Empty && state[0] == "category")
            {
                category = null;
                response = null;
            }
            else if (response == string.Empty && state[0] == "concept")
            {
                category = state[1];
                response = null;
            }
            else if (state[0] == "category")
            {
                category = state[1];
            }
                
            state = await GetCatalogEntry(category, response);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Type value or press [Enter] to exit.");
            Console.WriteLine();

            Console.Write("> ");
        } while ((response = Console.ReadLine()) != null);

    }

    private static async Task PrintConceptsForCategory(string category)
    {
        string catalogEntry = null;
            
        catalogEntry = await _client.GetStringAsync($"{_url}/{category}");
        var concepts = SplitLines(catalogEntry);

        Console.WriteLine($"Concepts under /{category}/ you can learn more about:\n");
        foreach (var c in concepts)
        {
            Console.WriteLine($"\t{c}");
        }
    }

    private static async Task PrintConceptForCategory(string category, string concept)
    {
        var catalogEntry = await _client.GetStringAsync($"{_url}/{category}/{concept}");
        Console.WriteLine(catalogEntry);
    }

    private static async string[] GetCatalogRequest(string category, string concept)
    {

        if (string.IsNullOrEmpty(category))
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
        else if (string.IsNullOrEmpty(concept))
        {
            string catalogEntry = null;
            
            try
            {
                catalogEntry = await _client.GetStringAsync($"{_url}/{category}");
            }
            catch
            {
                Console.WriteLine($"Not a valid category: {category}");
                return new[] {"invalid"};
            }
            var concepts = SplitLines(catalogEntry);

            Console.WriteLine($"Concepts under /{category}/ you can learn more about:\n");
            foreach (var c in concepts)
            {
                Console.WriteLine($"\t{c}");
            }
            return new[] {"category",category};
        }
        else 
        {
            var catalogEntry = await _client.GetStringAsync($"{_url}/{category}/{concept}");
            Console.WriteLine(catalogEntry);
            return  new[] {"concept",category,concept};
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