using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LimerickStreetArtApp.Models;
using MenuItem = LimerickStreetArtApp.Models.MenuItem;
using System.Collections.ObjectModel;

namespace LimerickStreetArtApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		//public ObservableCollection<navigationList> navigationList { get { return navigationList; } }

		//private  object navigationList;
		List<MenuItems> MenuItems;

		//private object navigationList;

		public MainPage()
		{

			InitializeComponent();

			MenuItems = new List<MenuItems>();

			MenuItems.Add(new MenuItems { OptionName = "Browse Products" });
			MenuItems.Add(new MenuItems { OptionName = "Your orders" });
			MenuItems.Add(new MenuItems { OptionName = "Categories" });
			MenuItems.Add(new MenuItems { OptionName = "Profile" });
			MenuItems.Add(new MenuItems { OptionName = "Settings" });
			MenuItems.Add(new MenuItems { OptionName = "Logout" });

			//navigationList.ItemSource = MenuItems;

			Detail = new NavigationPage(new BrowseProducts());
		}

		public object navigationList { get; private set; }

		private void Item_Tapped(object sender, ItemTappedEventArgs e)
		{
			try
			{
				var item = e.Item as MenuItems;

				switch (item.OptionName)
				{
					case "Browse Products":
						{
							Detail = new NavigationPage(new BrowseProducts());
							IsPresented = false;
						}
						break;
					case "Categories":
						{
							Detail = new NavigationPage(new Categories());
							IsPresented = false;
						}
						break;
					case "Profile":
						{
							Detail.Navigation.PushAsync(new Profile());
							IsPresented = false;
						}
						break;
				}
			}
			catch (Exception ex)
			{

			}
		}
	}

	public class MenuItems
	{
		public string OptionName { get; set; }
	}
}
