


namespace LimerickStreetArt.MobileForms.ViewModels
{
	using System;
	using Models;
	public class ItemDetailViewModel : BaseViewModel
	{
		public StreetArt Item { get; set; }
		public ItemDetailViewModel(StreetArt item = null)
		{
			Title = item?.Text;
			Item = item;
		}
	}
}
