using LimerickStreetArt.MobileForms.Models;
using LimerickStreetArt.MobileForms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LimerickStreetArt.MobileForms.ViewModels
{

	public class MasterMenuViewModels : INotifyPropertyChanged
	{
		public MasterMenuViewModels()
		{
			PopulateMenu();
		}

		private void PopulateMenu()
		{
			MenuItems = new ObservableCollection<MasterMenu>();
			MenuItems.Add(new MasterMenu { MenuName = "Loging", MenuIcon = "cartIcon", TargetType = typeof(Login) });
			MenuItems.Add(new MasterMenu { MenuName = "Items", MenuIcon = "itemsIcon", TargetType = typeof(ItemPage) });
			//MenuItems.Add(new MasterMenu { MenuName = "Transactions", MenuIcon = "transactionIcon", TargetType = typeof(TransactionPage) });
			MenuItems.Add(new MasterMenu { MenuName = "Settings", MenuIcon = "settingsIcon", TargetType = typeof(Search) });
			MenuItems.Add(new MasterMenu { MenuName = "About", MenuIcon = "aboutIcon", TargetType = typeof(AboutPage) });
		}

		ObservableCollection<MasterMenu> _menuItems;
		public ObservableCollection<MasterMenu> MenuItems
		{
			get
			{
				return _menuItems;
			}
			set
			{
				if (value != null)
				{
					_menuItems = value;
					OnPropertyChanged();
				}
			}
		}

		MasterMenu _selectedMenu;
		public MasterMenu SelectedMenu
		{
			get
			{
				return _selectedMenu;
			}
			set
			{
				if (_selectedMenu != null)
				{
					_selectedMenu.Selected = false;
					_selectedMenu.MenuIcon = _selectedMenu.MenuIcon.Substring(0, _selectedMenu.MenuIcon.Length - 6);
				}


				_selectedMenu = value;

				if (_selectedMenu != null)
				{
					_selectedMenu.Selected = true;
					_selectedMenu.MenuIcon += "_color";
					MessagingCenter.Send<MasterMenu>(_selectedMenu, "OpenMenu");
				}
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}


