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

        public CategoriesPage(string category, string categoryTitle)
        {
            InitializeComponent();

            Title = categoryTitle;

			var topics = Loader.GetTOCAsTuples($"NETCatalogApp.features.{category}._toc.csv");

            //var concepts = _categoryToConcepts[category].Keys.ToArray();
            int row = 0;

			foreach(var topic in topics)
            {
				var fileName = topic.Item1;
				var textualConceptName = topic.Item2;

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
			{
				Loader.StartRequestForConcept(category, conceptName);
				await Navigation.PushAsync(new ConceptPage(category, conceptName, niceConceptName));
			};

            label.GestureRecognizers.Add(labelTapRecognizer);
            return label;
        }

        private Image BuildImage(string category, string fileName, string niceConceptName)
        {
            var image = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromResource($"NETCatalogApp.features.{category}.{fileName}.png"),
            };

            var imageTapRecognizer = new TapGestureRecognizer();
			imageTapRecognizer.Tapped += async (s, e) =>
			{
				Loader.StartRequestForConcept(category,fileName);
				await Navigation.PushAsync(new ConceptPage(category, conceptName: fileName, niceConceptName: niceConceptName));
			};

            image.GestureRecognizers.Add(imageTapRecognizer);
            return image;
        }
    }
}