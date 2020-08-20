using LimerickStreetArt.MobileForms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using LimerickStreetArt;

namespace LimerickStreetArt.MobileForms.ViewModels
{
	public class LoginPage
	{


		public string Username { get; set; }
		public string Password { get; set; }
		public ICommand LoginCommand
		{
			get
			{
				return new Command(async () =>
				{
					//var = await apiServices.LoginAsync(Username, Password);


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


