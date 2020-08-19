namespace LimerickStreetArt.MobileForms.Views
{
	using LimerickStreetArt;
	using Models;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class NewItemPage : ContentPage
	{
		public LimerickStreetArt.StreetArt Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();

			Item = new LimerickStreetArt.StreetArt
			{
				Title = "Item name",
				Street = "This is an item description."
			};

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopModalAsync();
		}

		async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}