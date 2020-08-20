using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LimerickStreetArtApp.ViewModels
{
	class RegisterPage
	{
		readonly ApiServices _apiservices = ApiServiceFactory.GetApiServices();
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

					var isSuccess = await _apiservices.RegisterAsync(
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



