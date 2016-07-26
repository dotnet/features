using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NETCatalog
{
    public partial class CategoriesPage : ContentPage
    {
        // I feel dirty for hard-coding this but it was honestly the best solution at the time.
        private readonly Dictionary<string, Dictionary<string, string>> _categoryToConcepts = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "platform",
                new Dictionary<string, string>
                {
                    { "Async and Await",  "async-await" },
                    { "Delegates",  "delegates" },
                    { "Dynamic",  "dynamic" },
                    { "Extension Methods",  "extension-methods" },
                    { "Garbage Collection",  "garbage-collection" },
                    { "Generics",  "generics" },
                    { "Lambdas",  "lambdas" },
                    { "LINQ",  "linq" },
                    { ".NET Standard",  "netstandard" },
                    { "NuGet",  "nuget" },
                    { "Open Standards",  "open-standards" },
                    { "P/Invoke",  "p-invoke" },
                    { "Portable Class Libraries",  "portable-class-libraries" },
                    { "Reflection",  "reflection" },
                    { "SIMD",  "simd" },
                    { "Task Parallel Library",  "task-parallel-library" }
                }
             },
             {
                 "netcore",
                 new Dictionary<string, string>
                 {
                     { "Cross Platform", "cross-platform" },
                     { "Modular", "modular" },
                     { "Multicore JIT", "multi-core-jit" },
                     { "Open Source", "open-source" },
                     { "RyuJIT", "ryujit" },
                     { "Side by Side Installations", "side-by-side" }
                 }
             },
             {
                 "netfx",
                 new Dictionary<string, string>
                 {
                     { "ASP.NET Web Forms", "aspnet-webforms" },
                     { "ClickOnce Deployment", "click-once" },
                     { "Multicore JIT", "multi-core-jit" },
                     { "NGEN", "ngen" },
                     { "RyuJIT", "ryujit" },
                     { "WCF", "wcf" },
                     { "Windows Forms", "windows-forms" },
                     { "WPF", "wpf" }
                 }
             },
             {
                 "aspnetcore",
                 new Dictionary<string, string>
                 {
                     { "Cross Platform", "cross-platform" },
                     { "Microservices", "microservices" },
                     { "Modular", "modular" },
                     { "Open Source", "open-source" },
                     { "Performance", "performance" }
                 }
             },
             {
                 "uwp",
                 new Dictionary<string, string>
                 {
                     { ".NET Native", "net-native" },
                     { "Windows 10 Family of Devices", "win10-family" },
                     { "Windows Store", "windows-store" },
                     { "WinRT", "winrt" }
                 }
             },
             {
                 "vs",
                 new Dictionary<string, string>
                 {
                     { "Activity Tracing", "activity-tracing" },
                     { "Async Debugging", "async-debugging" },
                     { "C# REPL", "csharp-repl" },
                     { "Data Oriented Breakpoints", "data-oriented-breakpoints" },
                     { "Edit and Continue", "edit-and-continue" },
                     { "Managed Return Values", "managed-return-values" }
                 }
             },
             {
                 "xamarin",
                 new Dictionary<string, string>
                 {
                     { "Native Mobile", "native-mobile" },
                     { "Xamarin Forms", "xamarin-forms" },
                     { "Xamarin Studio", "xamarin-studio" },
                 }
             },
             {
                 "csharpvbfsharp",
                 new Dictionary<string, string>
                 {
                     { "C#", "csharp" },
                     {"Visual Basic", "vb" },
                     {"F#", "fsharp" }
                 }
             }
        };

        public CategoriesPage(string category, string categoryTitle)
        {
            InitializeComponent();

            Title = categoryTitle;

            var concepts = _categoryToConcepts[category].Keys.ToArray();
            int row = 0;

            for (int i = 0; i < concepts.Length; i++)
            {
                var fileName = _categoryToConcepts[category][concepts[i]];
                var textualConceptName = concepts[i];

                var image = BuildImage(category, fileName, textualConceptName);
                var label = BuildLabel(category, fileName, textualConceptName);

                var sl = new StackLayout
                {
                    Padding = new Thickness(20, 5, 5, 5),
                    Spacing = 10,
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children = { image, label }
                };

                CategoriesGrid.Children.Add(sl, 0, row++);
            }
        }

        private Label BuildLabel(string category, string conceptName, string niceConceptName)
        {
            var label = new Label
            {
                Text = niceConceptName,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.FromHex("#8b90ef")
            };

            var labelTapRecognizer = new TapGestureRecognizer();
            labelTapRecognizer.Tapped += async (s, e) =>
                await Navigation.PushAsync(new ConceptPage(category, conceptName, niceConceptName));

            label.GestureRecognizers.Add(labelTapRecognizer);
            return label;
        }

        private Image BuildImage(string category, string fileName, string niceConceptName)
        {
            var image = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromResource($"NETCatalog.App.{category}.{fileName}.png"),
            };

            var imageTapRecognizer = new TapGestureRecognizer();
            imageTapRecognizer.Tapped += async (s, e) =>
                await Navigation.PushAsync(new ConceptPage(category, conceptName: fileName, niceConceptName: niceConceptName));

            image.GestureRecognizers.Add(imageTapRecognizer);
            return image;
        }
    }
}