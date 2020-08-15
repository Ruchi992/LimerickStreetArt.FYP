using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using LimerickStreetArt;
//using LimerickStreetArt.UserAccount;
using Newtonsoft.Json;

namespace LimerickStreetArt.MobileForms.Services
{
	public class ApiServices
	{
		public async Task<bool> RegisterAsync(
			string email,
			string username,
			DateTime dateOfBirth,
			string password,
			string passwordConfirmation)
		{
			var client = new HttpClient();
			var model = new
			{
				Password = password,
				ReconformPassword = passwordConfirmation,
				Email = email,
				Username = username,
				DateOfBirth = dateOfBirth,
			};

			var jsonObject = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(jsonObject);

			var response = await client.PostAsync("https://localhost:44345/api/streetart", content);
			return response.IsSuccessStatusCode;
		}
		public async Task LoginAsync(string Username, string Password)
		{
			var keyValues = new List<KeyValuePair<string, string>>
		 {
			 new KeyValuePair<string, string>(Username,Username),
			 new KeyValuePair<string,string>(Password,Password),
		 };
			var request = new HttpRequestMessage(HttpMethod.Post, "url");
			request.Content = new FormUrlEncodedContent(keyValues);
			var client = new HttpClient();
			var response = await client.SendAsync(request);
			Debug.WriteLine(await response.Content.ReadAsStringAsync());
		}

	}
}
