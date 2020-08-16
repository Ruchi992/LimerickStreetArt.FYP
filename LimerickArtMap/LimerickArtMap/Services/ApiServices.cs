//using LimerickStreetArt.UserAccount;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimerickStreetArt.MobileForms.Services
{
	public interface ApiServices
	{
		object Constants { get; }

		Task LoginAsync(string Username, string Password);
		Task<bool> RegisterAsync(string email, string username, DateTime dateOfBirth, string password, string passwordConfirmation);
		Task<List<StreetArt>> SearchLocationAsync(string keyword, string accessToken);
	}
}