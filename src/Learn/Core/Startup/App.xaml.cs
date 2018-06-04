using Learn.Core.NativeInterfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace Learn.Core.Startup
{
	public partial class App : Application
	{
		public App (IPlatformInitializer platformInitializer)
		{
		    InitializeComponent();

            var bootstrapper = new AppBootstrapper(platformInitializer);
		    bootstrapper.Boot();
            MainPage = bootstrapper.CreateMainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
