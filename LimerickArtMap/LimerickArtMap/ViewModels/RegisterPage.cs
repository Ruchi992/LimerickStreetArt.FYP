using LimerickArtMap.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LimerickArtMap.ViewModels
{
	public class RegisterPage : BaseViewModel
	{
		readonly ApiServices _apiservices = new ApiServices();
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

					var isSuccess = await _apiservices.RegisterAsync(Email, Username, DateOfBirth, Password, ReconformPassword);

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






