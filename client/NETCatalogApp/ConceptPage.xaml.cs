using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommonMark;

using Xamarin.Forms;

namespace NETCatalog
{
    public partial class ConceptPage : ContentPage
    {
        private readonly string _baseUrl = "http://dotnet-features.azurewebsites.net/topics";
		//private Task<string> _getMarkdown = null;

        public ConceptPage(string category, string conceptName, string niceConceptName)
        {
			//_getMarkdown = GetConcept(category, conceptName);
            InitializeComponent();

            Title = niceConceptName;
        }

		private Task<string> GetConcept(string category, string concept)
		{
			var client = new HttpClient();
			return client.GetStringAsync($"{_baseUrl}/{category}/{concept}");
		}

        private void UpdateDisplay(string concept)
        {
            var htmlSource = new HtmlWebViewSource();

            var css = @"
            <style>
                body { background-color: #162129; font-family: 'Segoe UI, sans-serif'; color: #fff; }
                h1 { color: #8b90ef; font-family: 'Segoe UI', sans-serif; font-weight: 300; }
                a { color: #949AFF; font-weight: bold; text-decoration: none; }
            </style>
            ";

            htmlSource.Html = $"<html><head>{css}</head><body>{CommonMarkConverter.Convert(concept)}</body></html>";

            MarkdownWebView.Source = htmlSource;
        }

		protected override async void OnAppearing()
		{
			var concept = await Loader.GetRequestForConceptTask();
			UpdateDisplay(concept);
			base.OnAppearing();
		}
    }
}