using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace NETCatalog
{
	internal class Loader
	{
		private static readonly string _baseUrl = "http://dotnet-features.azurewebsites.net/topics";
		private static Task<string> _getConceptContent = null;

		internal static List<Tuple<string, string>> GetTOCAsTuples(string toc)
		{
			var assembly = typeof(TopicsPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream(toc);

			var items = new List<Tuple<string,string>>();

			using (var reader = new System.IO.StreamReader(stream))
			{
				var line = string.Empty;
				while ((line = reader.ReadLine()) !=null)
				{
					var strings = line.Split(',');
					items.Add(new Tuple<string, string>(strings[0], strings[1]));
				}
			}

			return items;
		}

		internal static void StartRequestForConcept(string category, string concept)
		{
			var client = new HttpClient();
			_getConceptContent = client.GetStringAsync($"{_baseUrl}/{category}/{concept}");
		}

		internal static Task<string> GetRequestForConceptTask()
		{
			var task = _getConceptContent;
			_getConceptContent = null;
			return task;
		}
	}
}
