using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LimerickStreetArt.MobileForms.ViewModels


{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;

		public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}

		private void InitializeComponent()
		{
			throw new NotImplementedException();
		}

		public ItemDetailPage()
		{
			InitializeComponent();

			var item = new StreetArt
			{
				Text = "Item 1",
				Title = "This is an item description."
			};

			viewModel = new ItemDetailViewModel(item);
			BindingContext = viewModel;
		}
	}
}