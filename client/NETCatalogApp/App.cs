using Xamarin.Forms;

namespace NETCatalog
{
    public class NETCatalogApp : Application
    {
        public NETCatalogApp()
        {
            MainPage = new NavigationPage(new TopicsPage());
        }
    }
}