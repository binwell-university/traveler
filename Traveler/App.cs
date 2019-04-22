using Traveler.DAL.DataServices;
using Traveler.UI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Traveler
{
	public class App : Application
	{
		public App ()
		{
			DialogService.Init(this);
			NavigationService.InitTabbed(InitializePages());
			DataServices.Init(true);
		}

        protected override void OnStart()
        {

        }

        private TabPageInitializer[] InitializePages()
        {
            var display = new TabPageInitializer() { Page = AppPages.Display, Title = "�������" };
            var calendar = new TabPageInitializer() { Page = AppPages.Calendar, Title = "���������" };
            var settings = new TabPageInitializer() { Page = AppPages.Settings, Title = "���������" };

            return new[] { display, calendar, settings };
        }
	}
}

