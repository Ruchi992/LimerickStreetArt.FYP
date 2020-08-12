using LimerickArtMap.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimerickArtMap.ViewModels
{
	public class RegisterPage
	{
		ApiServices _apiservices = new ApiServices();
		public String Password { get; set; }

		public String ReconformPassword { get; set; }
		public String Email { get; set; }

		public String Username { get; set; }

		public DateTime DateOfBirth { get; set; }
		public Icommand RegisterCommand
		{
			get
			{
				return new Command(() =>
				{
					_apiservices.RegisterAsync(Email, Username, DateOfBirth, Password, ReconformPassword);
				}
				);
			}
		}




	}

	internal class Command : Icommand
	{
		private Action p;

		public Command(Action p)
		{
			this.p = p;
		}
	}
}






