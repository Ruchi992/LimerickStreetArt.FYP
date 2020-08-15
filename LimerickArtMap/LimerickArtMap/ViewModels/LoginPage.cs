namespace LimerickStreetArt.MobileForms.ViewModels
{
	using System;
	using System.Windows.Input;
	using Xamarin.Forms;
	using Services;
	public class LoginPage
	{

		private readonly ApiServices _apiServices = new ApiServices();
		public String Password { get; set; }

		public Boolean RememberMe { get; set; }

		public String Username { get; set; }
		public ICommand LoginCommand
		{
			get
			{
				return new Command(async () =>
				{
					await _apiServices.LoginAsync(Username, Password);
				});
			}
		}
	}
}


