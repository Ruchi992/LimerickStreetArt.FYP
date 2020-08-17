
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LimerickStreetArt.MobileForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public string Name { get; private set; }

		public MapPage()
		{
			InitializeComponent();
		}
		private async void ButtonOpenCoords_Clicked(object sender, System.EventArgs e)
		{
			if (!double.TryParse(EntryLatitude.Text, out double lat))
				return;

			if (!double.TryParse(EntryLongitude.Text, out double lng))
				return;
			await Map.OpenAsync(lat, lng, new MapLaunchOptions
			{
				Name = EntryName.Text,
				NavigationMode = NavigationMode.None
			});

		}
	}
}