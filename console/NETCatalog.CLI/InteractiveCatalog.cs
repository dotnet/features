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
        string[] state = null;

        while (true)
        {

            // exit condition
            if (response == string.Empty && state == null)
            {
                return;
            }
            else
            {
                Console.Clear();
            }


            // base state - print categories
            if (response == null && state == null)
            {
                await PrintCategoriesforCatalog();
                Console.WriteLine();
                Console.WriteLine("Type value or press [Enter] to exit.");
            }
            // category selected - print concepts
            else if (response != string.Empty && state == null)
            {
                state = new[] {"category", response};
                //needs error handling for bad input
                await PrintConceptsForCategory(state[1]);
                Console.WriteLine();
                Console.WriteLine("Type value or press [Enter] to exit.");
            }
            // no concept selected (pressed Enter) - print categories
            else if (response == string.Empty && state != null && state[0] == "category")
            {
                // reset to initial state
                state = null;
                response = null;
                await PrintCategoriesforCatalog();
                Console.WriteLine();
                Console.WriteLine("Type value or press [Enter] to exit.");
            }              
            // concept select - print concept
            else if (response != String.Empty && state != null && state[0] == "category")
            {
                await PrintConceptForCategory(state[1], response);
                state = new[] {"concept", state[1], response};
                Console.WriteLine();
                Console.WriteLine("Press [Enter] when done.");
            }
            // done reading concept - print concepts for category
            else if (response == string.Empty && state != null && state[0] == "concept")
            {
                state = new[] {"category", state[1]};
                //needs error handling for bad input
                await PrintConceptsForCategory(state[1]);
                Console.WriteLine();
                Console.WriteLine("Type value or press [Enter] to exit.");
            }
                  
            Console.WriteLine();

            Console.Write("> ");
            response = Console.ReadLine();
        }

    }

    private static async Task PrintCategoriesforCatalog()
    {
        var catalogEntry = await _client.GetStringAsync(_url);
        var categories = SplitLines(catalogEntry);

        Console.WriteLine("Learn more about /dotnet/. Pick a feature category.\n");
        foreach (var c in categories)
        {
            Console.WriteLine($"\t{c}");
        }
    }

    private static async Task PrintConceptsForCategory(string category)
    {
        string catalogEntry = null;
            
        catalogEntry = await _client.GetStringAsync($"{_url}/{category}");
        var concepts = SplitLines(catalogEntry);

        Console.WriteLine($"Learn more about /{category}/. Pick a concept.\n");
        foreach (var c in concepts)
        {
            Console.WriteLine($"\t{c}");
        }
    }

    private static async Task PrintConceptForCategory(string category, string concept)
    {
        var catalogEntry = await _client.GetStringAsync($"{_url}/{category}/{concept}");
        Console.WriteLine($"You selected /{category}/{concept}/.\n");
        Console.WriteLine(catalogEntry);
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