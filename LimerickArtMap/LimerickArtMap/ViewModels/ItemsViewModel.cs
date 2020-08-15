namespace LimerickStreetArt.MobileForms.ViewModels
{
	using Models;
	using System;
	using System.Collections.ObjectModel;
	using System.Diagnostics;
	using System.Threading.Tasks;
	using Xamarin.Forms;
	using Views;
	using LimerickStreetArt;

	public class ItemsViewModel : BaseViewModel
	{
		public ObservableCollection<StreetArt> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel()
		{
			Title = "Browse";
			Items = new ObservableCollection<StreetArt>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemPage, StreetArt>(this, "AddItem", async (obj, item) =>
			{
				var newItem = item as StreetArt;
				Items.Add(newItem);
				await DataStore.AddItemAsync(newItem);
			});
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				foreach (var item in items)
				{
					Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}