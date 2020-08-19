using System;

using LimerickStreetArtApp.Models;

namespace LimerickStreetArtApp.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public ItemDetailViewModel(Item item = null)
		{
			Title = item?.Username;
			Item = item;
		}
	}
}
