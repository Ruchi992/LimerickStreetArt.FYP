using LimerickStreetArt.MobileForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LimerickStreetArt.MobileForms.ViewModels
{
	public class SearchLocation
	{
		private readonly ApiServices _apiServices = new ApiServices();
		private List<StreetArt> streetart;

		public List<StreetArt> StreetArt
		{
			get { return streetart; }
			set
			{
				streetart = value;
				OnPropertyChanged();
			}
		}

		public string Keyword { get; set; }

		public ICommand SearchCommand
		{
			get
			{
				return new Command(async () =>
				{
					StreetArt = await _apiServices.SearchLocationAsync(Keyword, "");
				});
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}