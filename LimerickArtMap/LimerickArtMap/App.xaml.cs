
namespace LimerickStreetArt.MobileForms
{
	using System;
	using Xamarin.Essentials;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;
	using Models;
	using Views;
	using Services;
	using ViewModels;
	using RegisterPage = ViewModels.RegisterPage;

	public partial class App : Application
	{
		//TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
		//To debug on Android emulators run the web backend against .NET Core not IIS
		//If using other emulators besides stock Google images you may need to adjust the IP address

		[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
