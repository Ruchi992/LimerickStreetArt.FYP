using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using LimerickStreetArtApp.Services;
namespace LimerickStreetArtApp.ViewModels
{
	public class LoginPage : BaseViewModel
	{
		private readonly ApiServices _apiServices = new ApiServices();
		public string Username { get; set; }
		public string Password { get; set; }
		public ICommand LoginCommand
		{
			get
			{
				return new Command(async () =>
				{
					//var accesstoken = await ApiServices.


				});
			}
		}

		public LoginPage()
		{
			//Username = Settings.Username;
			//Password = Settings.Password;
		}
	}
}





