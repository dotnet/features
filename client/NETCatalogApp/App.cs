using Xamarin.Forms;

namespace NETCatalog
{
    public class NETCatalogApp : Application
    {
        public NETCatalogApp()
        {
			MainPage = new NavigationPage(new TopicsPage())
			{
				BarBackgroundColor = Color.FromHex("#212238"),
				BarTextColor = Color.FromHex("#FFFFFF")
			};
        }
    }
}