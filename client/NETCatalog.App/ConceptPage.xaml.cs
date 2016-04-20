using System;
using System.Collections.Generic;
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
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "http://dotnet-buildtwentysixteendemo.azurewebsites.net/topics";

        public ConceptPage(string category, string conceptName, string niceConceptName)
        {
            InitializeComponent();

            Title = niceConceptName;

            // It's okay not to await this here rather than blocking the UI thread.
            GetMarkdownAndDisplayIt(category, conceptName);
        }

        private async Task GetMarkdownAndDisplayIt(string category, string concept)
        {
            var markdown = await _client.GetStringAsync($"{_baseUrl}/{category}/{concept}");

            var htmlSource = new HtmlWebViewSource();

            var css = @"
            <style>
                body { background-color: #162129; font-family: 'Segoe UI, sans-serif'; color: #fff; }
                h1 { color: #8b90ef; font-family: 'Segoe UI', sans-serif; font-weight: 300; }
                a { color: #949AFF; font-weight: bold; text-decoration: none; }
            </style>
            ";

            htmlSource.Html = $"<html><head>{css}</head><body>{CommonMarkConverter.Convert(markdown)}</body></html>";

            MarkdownWebView.Source = htmlSource;
        }
    }
}