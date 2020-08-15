namespace LimerickStreetArt.MobileForms.ViewModels
{
	using LimerickStreetArt;
	using Models;
	public class ItemDetailViewModel : BaseViewModel
	{
		public StreetArt Item { get; set; }
		public ItemDetailViewModel(StreetArt item = null)
		{
			Title = item?.Title;
			Item = item;
		}
	}
}
