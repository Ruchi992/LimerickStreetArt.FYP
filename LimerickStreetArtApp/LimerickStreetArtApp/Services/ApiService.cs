using LimerickStreetArt.MobileForms;
using LimerickStreetArt.MobileForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LimerickStreetArtApp.Services
{
	public class ApiService
	{
		public object Constants { get; private set; }

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

			var response = await client.PostAsync(AppUrls.streatArt, content);
			return response.IsSuccessStatusCode;
		}
		public async Task LoginAsync(string Username, string Password)
		{
			var keyValues = new List<KeyValuePair<string, string>>
		 {
			 new KeyValuePair<string, string>(Username,Username),
			 new KeyValuePair<string,string>(Password,Password),
		 };
			var request = new HttpRequestMessage(HttpMethod.Post, AppUrls.login)
			{
				Content = new FormUrlEncodedContent(keyValues)
			};
			var client = new HttpClient();
			var response = await client.SendAsync(request);
			Debug.WriteLine(await response.Content.ReadAsStringAsync());
		}
		public async Task<List<StreetArt>> SearchLocationAsync(string keyword, string accessToken)
		{
			var client = new HttpClient();
			//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearing", accessToken);
			var url = AppUrls.streatArtSearch + keyword;
			var json = await client.GetStringAsync(url);


			var streetArts = JsonConvert.DeserializeObject<List<StreetArt>>(json);

			return streetArts;
		}
	}
}

