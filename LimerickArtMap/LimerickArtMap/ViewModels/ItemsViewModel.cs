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
		public ObservableCollection<StreetArt> streetArts { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel()
		{
			Title = "Browse";
			streetArts = new ObservableCollection<StreetArt>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemPage, StreetArt>(this, "AddStreetart", async (obj, item) =>
			{
				var newItem = item as StreetArt;
				streetArts.Add(newItem);
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
				streetArts.Clear();
				var items = await DataStore.GetItemsAsync(true);
				foreach (var item in items)
				{
					streetArts.Add(item);
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