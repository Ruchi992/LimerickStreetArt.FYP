namespace LimerickStreetArt.MobileForms.Views
{
	using LimerickStreetArt.MobileForms.ViewModels;
	using Models;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Threading.Tasks;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();

			this.Title = "master";
			BindingContext = new MasterMenuViewModels();
			MessagingCenter.Subscribe<MasterMenu>(this, "OpenMenu", (Menu) =>
			{
				this.Detail = new NavigationPage((Page)Activator.CreateInstance(Menu.TargetType));
				IsPresented = false;
			});
		}

		private void InitializeComponent()
		{
			throw new NotImplementedException();
		}
	}
}
