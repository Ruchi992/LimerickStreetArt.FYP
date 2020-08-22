using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LimerickStreetArtApp.ViewModels
{
	using LimerickStreetArt.Services;
	using Services;
	public class RegisterPage : Page
	{
		readonly ApiService _apiservice;
		public String Password { get; set; }

		public String ReconformPassword { get; set; }
		public String Email { get; set; }

		public String Username { get; set; }

		public DateTime DateOfBirth { get; set; }
		public String Message { get; set; }
		public ICommand RegisterCommand
		{
			get
			{
				return new Command(async () =>
				{

					var isSuccess = await _apiservice.RegisterAsync(
						email: Email,
						username: Username,
						dateOfBirth: DateOfBirth,
						password: Password,
						passwordConfirmation: Password);

					if (isSuccess)
						Message = "Registered successfully";

					else
					{
						Message = "Register not success";
					}


				}
				);
			}
		}




	}
}



