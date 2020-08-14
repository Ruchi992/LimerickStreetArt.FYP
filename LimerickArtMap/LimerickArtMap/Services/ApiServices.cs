using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LimerickArtMap.Models;
using Newtonsoft.Json;

namespace LimerickArtMap.Services
{
	public class ApiServices
	{
		public async Task<bool> RegisterAsync(string email, string username, DateTime dateOfBirth, string password, string reconformPassword)
		{
			var client = new HttpClient();
			var model = new UserAccount
			{
				Password = password,
				Email = email,
				Username = username,
				DateOfBirth = dateOfBirth,


			};


			var jsonObject = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(jsonObject);

			var response = await client.PostAsync("https://localhost:44345/api/streetart", content);
			return response.IsSuccessStatusCode;
		}

	}
}
